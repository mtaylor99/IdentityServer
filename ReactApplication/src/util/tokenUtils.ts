import jwtDecode from 'jwt-decode';

export const getDecodedToken = <T>(token: Nullable<string>) => {
  const decodedToken = token !== null ? jwtDecode<T>(token) : null;

  if (!decodedToken) {
    return null;
  }

  return decodedToken;
};