import { Navigate, Route } from "react-router-dom"
import { PrivateRoutes } from "../../models/routes"
import LabPage from "./lab/LabPage"
import RoutesWhitNotFound from "../../utilities/routes-whit-not-found"

function Private() {
  return (
    <>
    <RoutesWhitNotFound>
      <Route path="/" element={<Navigate to={PrivateRoutes.LAB} />} />
      <Route path={PrivateRoutes.LAB} element={<LabPage />} />
    </RoutesWhitNotFound>
    </>
  )
}
export default Private