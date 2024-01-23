import React from "react";
import { Navigate, Outlet } from "react-router-dom";
import { useAuth } from "../hooks/AuthProvider";

const PrivateRoute = ({admin}) => {
  const user = useAuth();
  if (!user.isAuth) {
    return <Navigate to="/login" />
  } else if (admin && !user.adminId) {
    return <Navigate to="/" />
  }
  return <Outlet />;
};

export default PrivateRoute;