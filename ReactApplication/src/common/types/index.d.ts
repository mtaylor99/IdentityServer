/* eslint-disable @typescript-eslint/ban-ts-comment */
//@ts-nocheck
import { rest, SetupWorkerApi } from 'msw';

declare global {
  interface Window {
    msw: {
      worker: SetupWorkerApi;
      rest: typeof rest;
    };
  }
}
