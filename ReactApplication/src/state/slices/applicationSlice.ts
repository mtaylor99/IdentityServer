import { createSlice, PayloadAction } from "@reduxjs/toolkit";

export interface ApplicationState {
  notifications: number;
}

const initialState: ApplicationState = {
  notifications: 0,
};

export const applicationSlice = createSlice({
  name: "application",
  initialState,
  reducers: {
    incrementNotifications: (state) => {
      state.notifications += 1;
    },
    decrementNotifications: (state) => {
      state.notifications -= 1;
    },
    incrementNotificationsByAmount: (state, action: PayloadAction<number>) => {
      state.notifications += action.payload;
    },
  },
});

export const { incrementNotifications, decrementNotifications, incrementNotificationsByAmount } = applicationSlice.actions;

export const applicationReducer = applicationSlice.reducer;
