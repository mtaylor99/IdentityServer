# Base Template FE Development README

## Useful Info

This project has been created as a starting point for new project. It has the following tools installed and setup:-

Build Tool
  Vite https://vitejs.dev/

Development Tools
  Redux Toolkit https://redux-toolkit.js.org/
  RTK Query (API handling) https://redux-toolkit.js.org/rtk-query/overview

Authentication
  OIDC https://www.npmjs.com/package/oidc-react

Test Tools
  Vitest https://vitest.dev/
  Cypress https://docs.cypress.io/guides/overview/why-cypress
  Mock Service Worker https://mswjs.io/docs/
  ViTest UI - https://vitest.dev/guide/ui.html
  Code Coverage

UI Components
  Material UI including Themeing https://mui.com/
  Storybook https://storybook.js.org/

### Project Installation

npm install

npm run dev
npm run dev:mock

### Project Credentials

- To be started once authentication is built

## Patterns for Implementation

### Typescript

- Typescript must be used in all files where applicable. `.ts` and `.tsx`.

### Exports and Imports of React Component Definitions

- Avoid using default exports and imports, this is to create more consistency with naming. It also makes searching for component references much easier.
- Component props should always be defined using an `interface`, defined with convention `IComponentNameProps`
- Destructure the required props in the function arguments.
- In order to create named functions that display in the react devtools use the syntax:

```ts
  // defintion
  interface IFooProps {
    bar: number;
  }

  export function Foo({ bar }: IFooProps) { ... };

  ...
  // used in file
  import { Foo } from './Foo';
```

### Theme with MUI

- The typography, palette, mui component styling and spacing is all stored in a defaultTheme using mui's `createTheme()`
- Inline styles for containers and unique styling attributes can be added using the `sx={{ ... }}` prop.
- Avoid high specificity tags in css mark up to improve scalable styles.
- For adding theme for a new material ui component create a file in /src/styles/muiComponentThemes following the naming convention of muiComponentNameTheme.ts.
  Then import the created object into the defaultTheme file in the `components` property

```ts
  import { muiComponentTheme } from "./muiComponentThemes/muiComponentTheme";

  const theme: ThemeOptions = {
    components: {
      ...
      muiComponent: muiComponentTheme
    },
  };
```

### Using MUI in the project

- Use the MUI components straight out of the box in files as much as possible.

### Redux

- state folder is split into 2 sub folders -> selectors and slices. Prefix files with the same name, but ending in 'selectors', or 'reducer' or respectively.
- Selector definitions using `createSelector()`:

```ts
import { createSelector } from '@reduxjs/toolkit';
import { AppState } from 'state';

const selectAuthRoot = (state: AppState) => state.auth;

export const selectPartOfAuthState = createSelector(
  [selectAuthRoot],
  state => state.specificAuthState
);
```

## Testing

### Unit Testing

- follow query priority -> see docs https://testing-library.com/docs/queries/about/#priority
- use userEvent as much as possible over fireEvent.
- When accessing dom elements use screen queries:

```ts
// Import react testing library from "util/TestUtil"
import { render, screen } from 'util/TestUtil';
import { InlineBarChart } from './InlineBarChart';

describe('InlineBarChart', () => {
  const mock = [];
  it('inline bar chart renders correctly', () => {
    render(<InlineBarChart data={mock} />);

    const element = screen.queryByTestId('inline-bar-chart');

    expect(element).toBeInTheDocument();
  });
});
```

- When accessing dom elements that require global redux state, import the custom render function from TestUtil:

```ts
import { LiveTrackingWidget } from "./LiveTrackingWidget";
// Import react testing library from "util/TestUtil"
// Proxy has redux wrapper and exports RTL
import { IMockState, initialMockState, render, screen } from "util/TestUtil";

describe("LiveTrackingWidget", () => {
  const liveTrackingWidgetMockState: IMockState = {
    ...initialMockState,
    ...someMoreState
    },

  it("LiveTrackingWidget renders with title", async () => {
    // custom render function takes a Node and a state object.
    const testRenderer = render(<LiveTrackingWidget />, {
      preloadedState: liveTrackingWidgetMockState,
    });

    // access the dom through testRenderer
    const parent = testRenderer.queryByTestId("live-tracking-widget");

    expect(parent).toBeInTheDocument();
  });
});
```

Updating mock variations per test

```ts
import { server, rest } from 'mocks/server';
it('test that changes handler'),
  () => {
    server.use(
      rest.post(
        `${process.env.REACT_APP_API_URL}/api/users/history`,
        async (req, res, ctx) => {
          return res(ctx.status(500), ctx.json({ message: 'oh no it broke' }));
        }
      )
    );

    render(<Something />);
    // expect error message 'oh no it broke'
  };
```

```ts
import { render, screen } from 'util/testUtil';
it('header renders with nav items', () => {
  const authorisedMock: IMockState = {
    ...initialMockState,
    auth: {
      ...initialMockState.auth,
      authorised: true,
    },
  };
  render(<Header />, { preloadedState: authorisedMock });
  expect(screen.getByRole('link', { name: 'Complaints' })).toBeInTheDocument();
  expect(screen.getByRole('link', { name: 'Dashboard' })).toBeInTheDocument();
  expect(
    screen.getByRole('link', { name: 'Historical Complaints' })
  ).toBeInTheDocument();
});
```
