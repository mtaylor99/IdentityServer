export type DecodedIdToken = {
  iss: string;
  nbf: number;
  iat: number;
  exp: number;
  scope: string[];
  amr: string[];
  client_id: string;
  sub: string;
  auth_time: number;
  idp: string;
  given_name: string;
  family_name: string;
  role: string;
  permissions: string[];
  jti: string;
};
