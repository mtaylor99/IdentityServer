import { rest } from 'msw';
import { setupServer } from 'msw/lib/node';
import { handlers } from 'mocks/handlers';

const server = setupServer(...handlers);
export { server, rest };
