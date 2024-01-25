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
import ItemPage from './pages/ItemPage';
import EditCollection from './pages/EditCollection';

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
            <Route path="edit/collection/:id" element={<EditCollection />} />
            <Route path="dashboard" element={<PrivateRoute><MyCollection /></PrivateRoute>} />
            <Route path="collections" element={<Collections />} />
            <Route path="collection/:id" element={<CollectionPage />} />
            <Route path="item/:id" element={<ItemPage />} />
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
