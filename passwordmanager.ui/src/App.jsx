import { Routes, Route } from 'react-router-dom'
import Layout from './Layout/Layout'
import HomeComponent from './Components/HomeComponent';
import AddPasswordComponent from './Components/AddPasswordComponent';
import ViewPasswordsComponent from './Components/ViewPasswordsComponent';
import EditPasswordComponent from './Components/EditPasswordComponent';
function App() {
    return (
        <>
            <Routes>
                <Route path='/' element={<Layout />} >
                    <Route index element={<HomeComponent />} />
                    <Route path="/add" element={<AddPasswordComponent />} />
                    <Route path="/view" element={<ViewPasswordsComponent />} />
                    <Route path="/edit-password/:id" element={<EditPasswordComponent />} />
                </Route>

            </Routes>

        </>
    );
}


export default App;