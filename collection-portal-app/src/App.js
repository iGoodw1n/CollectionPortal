import { Route, BrowserRouter as Router, Routes } from 'react-router-dom';
import './App.css';
import PrivateRoute from './components/PrivateRoute';
import Login from './pages/Login';
import Dashboard from './pages/Dashboard';
import Home from './pages/Home';
import Header from './components/Header';
import Signup from './pages/Signup';
import AuthProvider from './hooks/AuthProvider';
import AddCollection from './pages/AddCollection';
import ThemeContextProvider from './contexts/ThemeContextProvider';

function App() {

  return (
    <Router>
      <ThemeContextProvider>
        <AuthProvider>
          <Header />
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="login" element={<Login />} />
            <Route path="signup" element={<Signup />} />
            <Route path="dashboard" element={<PrivateRoute><Dashboard /></PrivateRoute>} />
            <Route path="collection" element={<Dashboard />} />
            <Route path="collection/new" element={<AddCollection />} />
            {/* Other routes */}
          </Routes>
        </AuthProvider>
      </ThemeContextProvider>
    </Router>
  );
}

export default App;
