import axios from "axios";
import { useEffect } from "react";
import { useDispatch } from "react-redux";
import { setMessageBand } from "../redux/states/message-band.state";
import { MessageBandType } from "../models/message-band.model";
import { useSelector } from "react-redux";
import { AppStore } from "../redux/store";


const AxiosInterceptor = () => {
  const distpatcher = useDispatch();
  let AuthState = useSelector((state : AppStore) => state.auth)
  let token = AuthState.token
  console.log(token)

  useEffect(() => {
    const updateHeader = (request : any) => {
      const newHeader = {
        ...request.headers,
        Authorization: `Bearer ${token}`,
        "Content-Type": "application/json",
      };
      request.headers = newHeader;
      console.log( "header",request.headers)
      return request;
    };

    const requestInterceptor = axios.interceptors.request.use((request) => {
      if (request.url?.includes("aspi")) {
        console.log(request.url);
        return request;
      }
      return updateHeader(request);
    });

    const responseInterceptor = axios.interceptors.response.use(
      (response) => {
        return response;
      },
      (error) => {
        
        distpatcher(setMessageBand({ title: "ServiceError", message: error.response.data, type: MessageBandType.Error }));
        return Promise.reject(error);
      }
    );

    return () => {
      axios.interceptors.request.eject(requestInterceptor);
      axios.interceptors.response.eject(responseInterceptor);
    };
  }, []);

  return null;
};

export default AxiosInterceptor;