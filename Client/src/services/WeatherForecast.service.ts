import axios from "axios"

export default function WeatherForecastService( ): any {

    return axios.get('api/weatherforecast')
    
}