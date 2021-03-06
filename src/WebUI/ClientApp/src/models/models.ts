/* tslint:disable */
/* eslint-disable */
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.9.4.0 (NJsonSchema v10.3.1.0 (Newtonsoft.Json v12.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------
// ReSharper disable InconsistentNaming



export interface BaseContainer {
    containerId: number;
    userId: string;
    layoutId: string;
    layout: Layout;
    componentType: ComponentType;
}

export interface Layout {
    i: string;
    h: number;
    w: number;
    x: number;
    y: number;
}

export enum ComponentType {
    News = 0,
    Weather = 1,
    Portfolio = 2,
}

export interface AuditableEntity {
    created: Date;
    createdBy: string;
    lastModified: Date;
    lastModifiedBy: string;
}

export interface Equity extends AuditableEntity {
    id: number;
    ticker: string;
    type: EquityType;
    numberHeld: number;
    purchasePrice: number;
    portfolioId: number;
}

export enum EquityType {
    Stock = 0,
    Cryptocurrency = 1,
}

export interface Company {
    ticker: string;
    Company: string;
    listingDate: Date;
    industry: string;
}

export interface Quote {
    symbol: string;
    companyName: string;
    primaryExchange: string;
    calculationPrice: string;
    open: number;
    openTime: number;
    openSource: string;
    close: number;
    closeTime: number;
    closeSource: string;
    high: number;
    highTime: number;
    highSource: string;
    low: number;
    lowTime: number;
    lowSource: string;
    latestPrice: number;
    latestSource: string;
    latestTime: string;
    latestUpdate: number;
    latestVolume: number;
    iexRealtimePrice: number;
    iexRealtimeSize: number;
    iexLastUpdated: number;
    delayedPrice: number;
    delayedPriceTime: number;
    oddLotDelayedPrice: number;
    oddLotDelayedPriceTime: number;
    extendedPrice: number;
    extendedChange: number;
    extendedChangePercent: number;
    extendedPriceTime: number;
    previousClose: number;
    previousVolume: number;
    change: number;
    changePercent: number;
    volume: number;
    iexMarketPercent: number;
    iexVolume: number;
    avgTotalVolume: number;
    iexBidPrice: number;
    iexBidSize: number;
    iexAskPrice: number;
    iexAskSize: number;
    iexOpen: number;
    iexOpenTime: number;
    iexClose: number;
    iexCloseTime: number;
    marketCap: number;
    peRatio: number;
    week52High: number;
    week52Low: number;
    ytdChange: number;
    lastTradeTime: number;
    isUSMarketOpen: boolean;
    sector: string;
}

export interface NewsDto {
    status: string;
    totalResults: number;
    articles: Article[];
}

export interface Article {
    source: Source;
    author: string;
    title: string;
    description: string;
    url: string;
    urlToImage: string;
    publishedAt: Date;
    content: string;
}

export interface Source {
    id: string;
    name: string;
}

export interface PortfolioModel {
    equities: EquityModel[];
    id: number;
    userId: string;
}

export interface EquityModel {
    id: number;
    ticker: string;
    type: EquityType;
    numberHeld: number;
    purchasePrice: number;
    portfolioId: number;
    currentPrice: number;
    change: number;
}

export interface Control {
    containerId: number;
    container: BaseContainer;
}

export interface Portfolio extends Control {
    id: number;
    userId: string;
    containerId: number;
    container: BaseContainer;
    equities: Equity[];
}

export interface WeatherAndForecast {
    currentWeather: CurrentWeather;
    weather: WeatherDto;
}

export interface CurrentWeather {
    coord: Coord;
    weather: WeatherData[];
    base: string;
    main: DayTempDetails;
    visibility: number;
    wind: Wind;
    clouds: Clouds;
    dt: number;
    sys: DayDetails;
    timezone: number;
    id: number;
    name: string;
    cod: number;
}

export interface Coord {
    lon: number;
    lat: number;
}

export interface WeatherData {
    id: number;
    main: string;
    description: string;
    icon: string;
}

export interface DayTempDetails {
    temp: number;
    feelsLike: number;
    temp_min: number;
    temp_max: number;
    pressure: number;
    humidity: number;
}

export interface Wind {
    speed: number;
    deg: number;
    gust: number;
}

export interface Clouds {
    all: number;
}

export interface DayDetails {
    type: number;
    id: number;
    country: string;
    sunrise: number;
    sunriseDate: Date;
    sunset: number;
    sunsetDate: Date;
}

export interface WeatherDto {
    cod: number;
    message: number;
    cnt: number;
    list: Data[];
    city: CityDetails;
}

export interface Data {
    dt: number;
    main: MainClass;
    weather: WeatherElement[];
    clouds: Clouds;
    wind: Wind;
    visibility: number;
    pop: number;
    sys: Sys;
    dt_txt: Date;
    rain: Rain;
}

export interface MainClass {
    temp: number;
    feelsLike: number;
    temp_min: number;
    temp_max: number;
    pressure: number;
    seaLevel: number;
    grndLevel: number;
    humidity: number;
    tempKf: number;
}

export interface WeatherElement {
    id: number;
    main: string;
    description: string;
    icon: string;
}

export interface Sys {
    pod: string;
}

export interface Rain {
    "3h": number;
}

export interface CityDetails {
    id: number;
    name: string;
    coord: Coord2;
    country: string;
    population: number;
    timezone: number;
    sunrise: number;
    sunriseDate: Date;
    sunset: number;
    sunsetDate: Date;
}

export interface Coord2 {
    lat: number;
    lon: number;
}

export interface WeatherForecast {
    date: Date;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}

export interface FileResponse {
    data: Blob;
    status: number;
    fileName?: string;
    headers?: { [name: string]: any };
}