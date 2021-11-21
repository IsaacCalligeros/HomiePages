import React, { createRef, useEffect, useState } from "react";
import { useGeolocation } from "react-use";


const Weather = () => {
  const geo = useGeolocation();
  console.dir(geo.latitude);
  console.dir(geo.longitude);

  return (
    <>
    <div style={{width: '100%', height: '100%'}}>
      <iframe width="100%" height="100%" src={`https://embed.windy.com/embed2.html?lat=${geo.latitude}&lon=${geo.longitude}&detailLat=${geo.latitude}&detailLon=${geo.longitude}=0&height=0&zoom=6&level=surface&overlay=wind&product=ecmwf&menu=&message=&marker=&calendar=now&pressure=&type=map&location=coordinates&detail=&metricWind=default&metricTemp=default&radarRange=-1`}></iframe>
    </div>
        {/* <div>
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
        </div> */}
    </>
  );
};

export default Weather;
