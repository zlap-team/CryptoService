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
import LoginScreenDashboard from './Screens/LoginScreenForum'
import HomeScreen from './Screens/HomeScreen'
import ForumScreen from './Screens/ForumScreen';
import NewRoomFormComponent from './Components/NewRoomFormComponent';
import PostScreen from './Screens/PostScreen';
import SingleCryproScreen from './Screens/SingleCryproScreen';
import PostScreen2 from './Screens/PostScreen2';
import LoginScreenForum from './Screens/LoginScreenForum'
import RedirectComponent from './Components/RedirectComponent';
function App() {
  return (
    <Router>
      <Header />
      <main className='py-5'>
        <Container>
          <Routes>
            <Route path='/' element={<HomeScreen />}/>
            <Route path="/login" element={<LoginScreen/>} />
            <Route path="/loginForum" element={<LoginScreenForum/>} />
            <Route path="/forum" element={<ForumScreen/>} />
            <Route path="/create_new_post" element={<NewRoomFormComponent/>} />
            <Route path="/post/:id" element={<PostScreen/>} />
            <Route path="/register" element={<RegisterScreen/>} />
            <Route path='/news' element={<NewsScreen />} />
            <Route path='/bank' element={<BankScreen />} />
            <Route path='/economy' element={<EconomyScreen />} />
            {/* <Route path='/dashboard' element={<DashBoardScreen />} /> */}
            <Route path='/crypto/:id' element={<SingleCryproScreen />} />
          </Routes>
        </Container>
      </main>
      <Footer />
    </Router>
  );
}

export default App;
