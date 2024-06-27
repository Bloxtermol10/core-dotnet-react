import { Navigate, Route } from "react-router-dom"
import { PrivateRoutes } from "../../models/routes"
import RoutesWhitNotFound from "../../utilities/routes-whit-not-found"
import { lazy } from "react"
const LabPage = lazy(() => import("./lab/LabPage"))

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