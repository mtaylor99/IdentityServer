import {
  addMinutes,
  endOfMonth,
  format,
  startOfMonth,
  subDays,
  subMonths,
} from 'date-fns';

export const getUkDateStringFromJsonDateString = (jsonDateString: string) => {
  return new Date(jsonDateString).toLocaleDateString('en-GB');
};

export const getPrettyDateStringFromJsonDateString = (
  jsonDateString: string
) => {
  return new Date(jsonDateString).toLocaleDateString('en-GB', {
    day: '2-digit',
    month: 'short',
    year: 'numeric',
  });
};

export const GetStartDateOfLastMonth = () => {
  const timeZoneOffset = new Date().getTimezoneOffset();

  let startDateMonth = startOfMonth(subMonths(new Date(), 1));
  startDateMonth = addMinutes(startDateMonth, timeZoneOffset * -1);

  return startDateMonth;
};

export const GetEndDateOfLastMonth = () => {
  const endDateMonth = endOfMonth(subMonths(new Date(), 1));

  return endDateMonth;
};

export const GetDateDaysAgo = (daysAgo: number) => {
  const timeZoneOffset = new Date().getTimezoneOffset();

  let dateDaysAgo = subDays(new Date(), daysAgo);
  dateDaysAgo = addMinutes(dateDaysAgo, timeZoneOffset * -1);

  return dateDaysAgo;
};

export const getDateOnlyIsoString = (val: Date) => format(val, 'yyyy-MM-dd');
