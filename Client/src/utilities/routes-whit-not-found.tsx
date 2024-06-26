import { Route, Routes } from "react-router-dom"
import NotFond from "../pages/notFound/NotFond"


interface Props{
    children: JSX.Element | JSX.Element[]
}
function RoutesWhitNotFound({children}: Props) {
  return (
    <Routes>
        {children}
        <Route path="*" element={<NotFond />} />
    </Routes>
  )
}

export default RoutesWhitNotFound