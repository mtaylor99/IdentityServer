import { describe, expect, test } from 'vitest';
// import { store } from '../state/store';
import { initialMockState } from '../utils/testUtil';

describe('With React Testing Library', () => {
  test('Drivers loaded into state', async () => {
    const applicationState = initialMockState.application;

    const initialNotificationsCount = applicationState.notifications;

    expect(initialNotificationsCount).toEqual(undefined);
  });

//   test('Loads job statuses into state', async () => {
//     let applicationState = store.getState().application;

//     const initialNotificationsCount = applicationState.notifications;

//     await applicationState.dispatch(getJobStatuses() as any);

//     applicationState = store.getState().application;
//     expect(applicationState.notifications).toBeGreaterThan(initialNotificationsCount);
//   });
});
