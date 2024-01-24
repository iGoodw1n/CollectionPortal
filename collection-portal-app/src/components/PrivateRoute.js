import React from "react";
import { Navigate, Outlet } from "react-router-dom";
import { useAuth } from "../hooks/AuthProvider";

const PrivateRoute = ({admin}) => {
  const user = useAuth();
  if (!user.authData) {
    return <Navigate to="/login" />
  } else if (admin && !user.authData.isAdmin) {
    return <Navigate to="/" />
  }
  return <Outlet />;
};

export default PrivateRoute;