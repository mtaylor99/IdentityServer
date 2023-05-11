import { describe, expect, test } from 'vitest';
import { decrementNotifications, incrementNotifications } from '../state/slices/applicationSlice';
import { configureReduxStore } from '../state/store';

describe('With React Testing Library', () => {
  test('Application Notifications loaded into state', async () => {
    const store = configureReduxStore();
    const applicationState = store.getState().application;

    const initialNotificationsCount = applicationState.notifications;

    expect(initialNotificationsCount).toEqual(0);
  });

  test('Application Notifications Incremented', async () => {
    const store = configureReduxStore();
    let applicationState = store.getState().application;

    const initialNotificationsCount = applicationState.notifications;

    await store.dispatch(incrementNotifications());

    applicationState = store.getState().application;
    expect(applicationState.notifications).toEqual(1);

    await store.dispatch(incrementNotifications());

    applicationState = store.getState().application;
    expect(applicationState.notifications).toBeGreaterThan(initialNotificationsCount);
    expect(applicationState.notifications).toEqual(2);
  });

  test('Application Notifications Decremented', async () => {
    const store = configureReduxStore();
    let applicationState = store.getState().application;

    await store.dispatch(decrementNotifications());

    applicationState = store.getState().application;
    expect(applicationState.notifications).toEqual(-1);

    await store.dispatch(decrementNotifications());

    applicationState = store.getState().application;
    expect(applicationState.notifications).toEqual(-2);
  });
});
