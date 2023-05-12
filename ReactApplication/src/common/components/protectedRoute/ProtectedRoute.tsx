import { useAuth } from 'oidc-react';
import { Outlet } from 'react-router-dom';

import { useCurrentUserPermissions } from '../../../hooks/useCurrentUserPermissions';
import { NoPermissionsPage } from '../../../pages/noPermissionsPage/NoPermissionsPage';
import { UserPermissions } from '../../../types/userPermissions';

export interface IProtectedRouteProps {
  requiredPermissions: UserPermissions[];
  children?: JSX.Element;
  redirectPath?: string;
}

export const ProtectedRoute = (props: IProtectedRouteProps) => {
  const { requiredPermissions, children } = props;
  const canUserViewRoute = useCanUserViewRoute(requiredPermissions);

  return canUserViewRoute ? (
    children ? (
      children
    ) : (
      <Outlet />
    )
  ) : (
    <NoPermissionsPage />
  );
};

const useCanUserViewRoute = (requiredPermissions: UserPermissions[]) => {
  const authContext = useAuth();
  const { doesUserHaveSomeOfThesePermissions } = useCurrentUserPermissions();
  if (authContext.userData?.access_token) {
    // User has access token which means they're authenticated
    // Check if they have the relevant permissions

    const canView = doesUserHaveSomeOfThesePermissions(requiredPermissions);
    return canView;
  }

  // No token which means user is anonymous, return false
  return false;
};
