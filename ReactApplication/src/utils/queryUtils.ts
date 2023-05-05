import { fetchBaseQuery } from '@reduxjs/toolkit/dist/query/react';
import { getOidcConfig } from './authUtils';

export const customFetchBaseQuery = (baseUrl: string) => {
  return fetchBaseQuery({
    baseUrl,
    prepareHeaders: customPrepareHeaders,
    credentials: 'include',
  });
};

export const customPrepareHeaders = (headers: Headers) => {
  headers.set('accept', 'application/json');

  // oidc-react stores the access token in session storage
  // Get the access token from session storage and write to the authorization header
  const oidcSessionStorageKey = `oidc.user:${getOidcConfig().authority}:${
    getOidcConfig().clientId
  }`;
  const oidcDataString = sessionStorage.getItem(oidcSessionStorageKey);
  const oidcData = oidcDataString ? JSON.parse(oidcDataString) : {};
  const token = oidcData?.access_token;

  if (token) {
    headers.set('authorization', `Bearer ${token}`);
  }

  return headers;
};

interface IGetUrlSearchParamFromQueryDataParams {
  skip: number;
  take: number;
  sortBy: string;
  sortDirection: string;
  searchValue: string | null | undefined;
}

export const getUrlSearchParamFromQueryData = ({
  skip,
  take,
  sortBy,
  sortDirection,
  searchValue,
}: IGetUrlSearchParamFromQueryDataParams) => {
  const queryParams = new URLSearchParams({
    skip: skip.toString(),
    take: take.toString(),
    sortBy,
    sortDirection,
  });

  if (
    searchValue !== null &&
    searchValue !== undefined &&
    searchValue.length > 0
  ) {
    queryParams.append('searchText', searchValue);
  }

  return queryParams;
};

export const getPaginatedQuery = (
  mainUrl: string,
  queryData: IGetUrlSearchParamFromQueryDataParams
) => {
  const queryParamsStr = getUrlSearchParamFromQueryData(queryData);

  return `${
    process.env.REACT_APP_API_URL
  }${mainUrl}${queryParamsStr.toString()}`;
};
