import React, { useState, useEffect } from "react";
import axiosInstance from "../../axiosInstance";
import WeatherTypes from "./types";

const Weather = () => {
  const [loading, setLoading] = useState(true);
  const [forecasts, setForecasts] = useState<WeatherTypes.forecast[]>([]);

  useEffect(() => {
      axiosInstance.get("/weatherforecast").then((res) => {
        setForecasts(res.data);
        setLoading(false);
      });
  }, []);

  return (
    <>
        <div>
          <table className="table table-striped" aria-labelledby="tabelLabel">
            <thead>
              <tr>
                <th>Date</th>
                <th>Temp. (C)</th>
                <th>Temp. (F)</th>
                <th>Summary</th>
              </tr>
            </thead>
            <tbody>
              {forecasts.map((forecast, idx) => (
                <tr key={idx}>
                  <td>{forecast.date}</td>
                  <td>{forecast.temperatureC}</td>
                  <td>{forecast.temperatureF}</td>
                  <td>{forecast.summary}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
    </>
  );
};

export default Weather;
