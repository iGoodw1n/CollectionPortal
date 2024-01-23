import { Route, BrowserRouter as Router, Routes } from 'react-router-dom';
import './App.css';
import PrivateRoute from './components/PrivateRoute';
import Login from './pages/Login';
import Home from './pages/Home';
import Header from './components/Header';
import Signup from './pages/Signup';
import AuthProvider from './hooks/AuthProvider';
import AddCollection from './pages/AddCollection';
import ThemeContextProvider from './contexts/ThemeContextProvider';
import MyCollection from './pages/MyCollection';
import Collections from './components/Collections';
import CollectionPage from './pages/CollectionPage';
import AdminPage from './pages/AdminPage';

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
            <Route path="dashboard" element={<PrivateRoute><MyCollection /></PrivateRoute>} />
            <Route path="my-collection" element={<Collections />} />
            <Route path="collection/:id" element={<CollectionPage />} />
            <Route path="collection/new" element={<AddCollection />} />
            <Route element={<PrivateRoute admin={true}/>} >
              <Route path="admin" element={<AdminPage />} />
            </Route>
            {/* Other routes */}
          </Routes>
        </AuthProvider>
      </ThemeContextProvider>
    </Router>
  );
}

export default App;
