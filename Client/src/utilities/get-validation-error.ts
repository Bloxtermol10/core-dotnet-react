import { TypeWithKey } from "../models/type-with-key";

export function getValidationError(errorCode: any) {{
    const codeMatcher : TypeWithKey<string> = {
        ERR_NETWORK: "se rompoio la red",
        ERR_NETWORK_TIMEOUT: "Se rompio el tiempo de espera",
        ERR_NETWORK_CLOSED: "Se cerro la red",
        ERR_NETWORK_ABORT: "Se aborto la red",
        ERR_BAD_RESPONSE: "Se rompio la respuesta",
        ERR_BAD_REQUEST: "Se rompio la peticion",
    }

    return codeMatcher[errorCode]
}}