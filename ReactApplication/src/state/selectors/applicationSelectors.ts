import { createSelector } from "@reduxjs/toolkit";
import { AppState } from "../store";

export const selectApplicationRoot = (state: AppState) => state.application;

export const selectNotifications = createSelector(
  [selectApplicationRoot],
  (application) => application.notifications
);
