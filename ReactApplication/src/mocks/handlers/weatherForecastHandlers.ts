import { rest } from 'msw'
import { weatherForecastData } from '../data/weatherForecastData'

export const weatherForecastHandlers = [
  rest.get(
    `${import.meta.env.VITE_APP_API_URL}/WeatherForecast`,
    (req, res, ctx) => {
      if (import.meta.env.VITE_APP_IS_STRICT_MOCKS === 'yes') {
        return res(ctx.status(200), ctx.json(weatherForecastData));
      }
      return req.passthrough();
    }
  ),
]