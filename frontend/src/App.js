import { Container } from 'react-bootstrap';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'

import { useSelector } from 'react-redux';

import LoginModal from './Components/LoginModal';
import RegisterModalComponent from './Components/RegisterModalComponent'
import Header from './Components/Header';
import Footer from './Components/Footer';
import HomeComponent from './Components/HomeComponent'
import NewsComponent from './Components/NewsComponent';
import NewsScreen from './Screens/NewsScreen';
import BankScreen from './Screens/BankScreen';
import EconomyScreen from './Screens/EconomyScreen';
import DashBoardScreen from './Screens/DashBoardScreen';

function App() {
  const value = useSelector((state) => state.modal.value)
  const registerValue = useSelector((state) => state.registerModal.value)
  
  return (
    <Router>
      {value && <LoginModal />}
      {registerValue && <RegisterModalComponent />}
      {value ? <LoginModal /> : <Header />}
      <main className='py-5'>
        <Container>
          <Routes>
            <Route path='/' element={<HomeComponent />} />
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
