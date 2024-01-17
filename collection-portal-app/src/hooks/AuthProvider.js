import { useContext, createContext, useState } from "react";
import { useNavigate } from "react-router-dom";
import { instance } from "../api.config.js";

const AuthContext = createContext();

const AuthProvider = ({ children }) => {
  const [isAuth, setIsAuth] = useState(false);

  const navigate = useNavigate();

  const loginAction = async (data) => {
    try {
      const response = await instance.post("/account/login", data);
      console.log(response)
      if (response) {
        if (response.status === 401) return 'Password or email is incorrect'
        setIsAuth(true);
        localStorage.setItem("token", response.data.accessToken);
        localStorage.setItem("refreshToken", response.data.refreshToken);
        navigate("/");
      }

      throw new Error(response?.statusText);
    } catch (err) {
      console.error(err);
    }
  };

  const signUpAction = async (data) => {
    try {
      const response = await fetch("/account/register", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      });
      if (response.status === 400) {
        const errorResult = await response.json()
        return errorResult.errors.DuplicateUserName?.[0] || 'Something goes wrong. Try again'
      }
      navigate("/login");
    } catch (err) {
      console.error(err);
    }
  };

  const checkAuth = async () => {
    const refreshToken = localStorage.getItem('refreshToken')
    if (!refreshToken) return
    const response = await instance.post("/account/refresh", { refreshToken })
    if (response && response.status) {
      setIsAuth(true);
      localStorage.setItem("token", response.data.accessToken);
      localStorage.setItem("refreshToken", response.data.refreshToken);
      navigate("/");
    }
  }

  const logOut = () => {
    setIsAuth(false);
    localStorage.removeItem("token");
    localStorage.removeItem("refreshToken");
    navigate("/login");
  };

  return (
    <AuthContext.Provider value={{ isAuth, loginAction, logOut, signUpAction, checkAuth }}>
      {children}
    </AuthContext.Provider>
  );

};

export default AuthProvider;

export const useAuth = () => {
  return useContext(AuthContext);
};