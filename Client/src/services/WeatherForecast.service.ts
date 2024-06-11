import axios from "axios"

export default function WeatherForecastService( ) {

    return axios.get('api/weatherforecast')
    
}