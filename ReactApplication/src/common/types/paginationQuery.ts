import { ESortDirection } from '../enums/ESortDirection';

export interface IPaginationQuery {
  skip: number;
  take: number;
  searchValue?: Nullable<string>;
}

export interface IPaginationWithSortQuery<T> extends IPaginationQuery {
  sortBy: T;
  sortDirection: ESortDirection;
}
