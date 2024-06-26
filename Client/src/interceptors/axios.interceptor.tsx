import axios from "axios";
import { MessageBandUtilities } from "../utilities/message-band-manager";
import { getValidationError } from "../utilities/get-validation-error";
import { useEffect } from "react";
import { useDispatch } from "react-redux";
import { setMessageBand } from "../redux/states/message-band.state";
import { MessageBandType } from "../models/message-band.model";

const AxiosInterceptor = () => {
  const distpatcher = useDispatch();

  useEffect(() => {
    const updateHeader = (request : any) => {
      const token = localStorage.getItem("token");
      const newHeader = {
        ...request.headers,
        Authorization: `Bearer ${token}`,
        "Content-Type": "application/json",
      };
      request.headers = newHeader;
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
        console.log("response", response);
        return response;
      },
      (error) => {
        distpatcher(setMessageBand({ title: "ServiceError", message: error.message, type: MessageBandType.Error }));
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