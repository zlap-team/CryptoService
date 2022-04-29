import { Container } from 'react-bootstrap';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'

import { useSelector } from 'react-redux';


import Header from './Components/Header';
import Footer from './Components/Footer';
import HomeComponent from './Components/HomeComponent'
import NewsComponent from './Components/NewsComponent';
import NewsScreen from './Screens/NewsScreen';
import BankScreen from './Screens/BankScreen';
import EconomyScreen from './Screens/EconomyScreen';
import DashBoardScreen from './Screens/DashBoardScreen';
import LoginScreen from './Screens/LoginScreen';
import RegisterScreen from './Screens/RegisterScreen';
import LoginScreenDashboard from './Screens/LoginScreenDashboard'
import HomeScreen from './Screens/HomeScreen'

function App() {
  return (
    <Router>
      <Header />
      <main className='py-5'>
        <Container>
          <Routes>
            <Route path='/' element={<HomeScreen />}/>
            <Route path="/login" element={<LoginScreen/>} />
            <Route path="/loginDashboard" element={<LoginScreenDashboard/>} />
            <Route path="/register" element={<RegisterScreen/>} />
            <Route path='/news' element={<NewsScreen />} />
            <Route path='/bank' element={<BankScreen />} />
            <Route path='/economy' element={<EconomyScreen />} />
            <Route path='/dashboard' element={<DashBoardScreen />} />
          </Routes>
        </Container>
      </main>
      <Footer />
    </Router>
  );
}

export default App;
