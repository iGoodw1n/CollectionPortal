import { useState } from "react";
import ThemeContext from "./ThemeContext";

const ThemeContextProvider = ({children}) => {
  const [theme, setTheme] = useState(localStorage.getItem('theme') || 'light')
  
  const switchTheme = () => {
    setTheme(prev => {
      const newTheme = prev === 'light' ? 'dark' : 'light'
      localStorage.setItem('theme', newTheme)
      return newTheme
    })
  }
  
  return (
    <ThemeContext.Provider value={[theme, switchTheme]}>
      {children}
    </ThemeContext.Provider>
  )
}

export default ThemeContextProvider