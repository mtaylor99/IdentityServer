/* eslint-disable @typescript-eslint/ban-ts-comment */
//@ts-nocheck

import { rest, setupWorker } from 'msw';
import { handlers } from './handlers';

export type Test = typeof rest;

export const worker = setupWorker(...handlers);
export { rest };

window.msw = {
  worker,
  rest,
};
