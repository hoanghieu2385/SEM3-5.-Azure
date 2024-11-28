import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import ClassList from './components/GetClass';
import AddClass from './components/AddClass';
// import UpdateClass from './components/Class/UpdateClass';
import './App.css'

const App = () => {
  return (
    <Router>
      <Routes>
        <Route exact path="/" element={<ClassList />} />
        <Route path="/add-class" element={<AddClass />} />
        {/* <Route path="/edit-class/:id" element={<UpdateClass />} /> */}
      </Routes>
    </Router>
  );
};

export default App;