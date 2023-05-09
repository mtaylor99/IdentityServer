import { defineConfig } from "cypress";

export default defineConfig({
  e2e: {
    setupNodeEvents(on, config) {
      // implement node event listeners here
    },
  },
  env: {
    app_url: "http://127.0.0.1:3000",
    auth0_username: "mathew.taylor",
    auth0_password: "Password1!",
    auth0_domain: "https://localhost:5001",
    auth0_audience: "process.env.REACT_APP_AUTH0_AUDIENCE",
    auth0_scope: "https://127.0.0.1:5003/api offline_access profile openid",
    auth0_client_id: "9f35adbd-8db7-4a0f-aeec-ee22594e1a96",
    auth0_client_secret: "secret",
  },
});
