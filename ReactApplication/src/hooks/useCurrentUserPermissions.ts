import { IDecodedAccessToken } from '../types/decodedToken';
import { UserPermissions } from '../types/userPermissions';
import { useDecodedAccessToken } from './useDecodedAccessToken';

export const useCurrentUserPermissions = () => {
  const { decodedAccessToken } = useDecodedAccessToken();

  const permissions =
    (decodedAccessToken as IDecodedAccessToken)?.api_permissions ?? [];

  const doesUserHaveSinglePermission = (permissionName: UserPermissions) => {
    return permissions.includes(permissionName);
  };

  const doesUserHaveSomeOfThesePermissions = (
    permissionNames: readonly UserPermissions[]
  ) => {
    return permissionNames.some(doesUserHaveSinglePermission);
  };

  const doesUserHaveAllOfThesePermissions = (
    permissionNames: readonly UserPermissions[]
  ) => {
    return permissionNames.every(doesUserHaveSinglePermission);
  };

  return {
    permissions,
    doesUserHaveSinglePermission,
    doesUserHaveSomeOfThesePermissions,
    doesUserHaveAllOfThesePermissions,
  };
};
