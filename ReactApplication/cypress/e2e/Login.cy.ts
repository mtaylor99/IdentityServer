describe('Login', function () {
  beforeEach(function () {
    cy.visit(Cypress.env('app_url'))

    cy.loginToAuth0(
      Cypress.env('idp_username'),
      Cypress.env('idp_password')
    )
  })

  it('can log into application', function () {
    cy.contains('Vite + React').should('be.visible')
  })
})