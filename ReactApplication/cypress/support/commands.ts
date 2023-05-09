/// <reference types="cypress" />
// ***********************************************
// This example commands.ts shows you how to
// create various custom commands and overwrite
// existing commands.
//
// For more comprehensive examples of custom
// commands please read more here:
// https://on.cypress.io/custom-commands
// ***********************************************
//
//
// -- This is a parent command --
// Cypress.Commands.add('login', (email, password) => { ... })
//
//
// -- This is a child command --
// Cypress.Commands.add('drag', { prevSubject: 'element'}, (subject, options) => { ... })
//
//
// -- This is a dual command --
// Cypress.Commands.add('dismiss', { prevSubject: 'optional'}, (subject, options) => { ... })
//
//
// -- This will overwrite an existing command --
// Cypress.Commands.overwrite('visit', (originalFn, url, options) => { ... })
//
// declare global {
//   namespace Cypress {
//     interface Chainable {
//       login(email: string, password: string): Chainable<void>
//       drag(subject: string, options?: Partial<TypeOptions>): Chainable<Element>
//       dismiss(subject: string, options?: Partial<TypeOptions>): Chainable<Element>
//       visit(originalFn: CommandOriginalFn, url: string, options: Partial<VisitOptions>): Chainable<Element>
//     }
//   }
// }

function loginViaAuth0Ui(username: string, password: string) {
  // Login on Auth0.
  cy.origin(
    Cypress.env('idp_domain'),
    { args: { username, password } },
    ({ username, password }) => {
      cy.get('input[name="Input.Username"]').type(username);
      cy.get('input[name="Input.Password"]').type(password, { log: false });
      cy.contains('button', 'Login').click();
    }
  );

  // Ensure Auth0 has redirected us back to the RWA.
  cy.url().should('include', Cypress.env('app_url'))
}

Cypress.Commands.add('loginToAuth0', (username: string, password: string) => {
  const log = Cypress.log({
    displayName: 'AUTH0 LOGIN',
    message: [`🔐 Authenticating | ${username}`],
    autoEnd: false,
  })
  log.snapshot('before')

  loginViaAuth0Ui(username, password)

  log.snapshot('after')
  log.end()
});
