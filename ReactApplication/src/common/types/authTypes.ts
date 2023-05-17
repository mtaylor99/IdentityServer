export interface ITokenResponse {
  accessToken: string;
}

export interface IAuthLoginRequest {
  username: string;
  password: string;
}

export interface IAuthLoginResponse {
  access_token: string;
  expires_in: number;
  token_type: string;
  refresh_token: string;
  scope: string;
}
