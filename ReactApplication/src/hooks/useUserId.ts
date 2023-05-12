import { IDecodedAccessToken } from "../types/decodedToken";
import { useDecodedAccessToken } from "./useDecodedAccessToken";

export const useUserId = () => {
  const { decodedAccessToken } = useDecodedAccessToken();
  const userId = (decodedAccessToken as IDecodedAccessToken)?.sub;

  if (!userId) {
    throw new Error('Could not get user id from access token');
  }

  return { userId };
};
