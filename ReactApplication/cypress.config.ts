import { defineConfig } from "cypress";

export default defineConfig({
  e2e: {
    setupNodeEvents(on, config) {
      // implement node event listeners here
    },
  },
  env: {
    app_url: "http://127.0.0.1:3000",
    idp_domain: "https://localhost:5001",
    idp_username: "mathew.taylor",
    idp_password: "Password1!",
  },
});
