import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import '../../node_modules/bootstrap/dist/css/bootstrap.css'

const AddClass = () => {
    const [className, setClassName] = useState('');
    const [roomName, setRoomName] = useState('');

    const [error, setError] = useState('');

    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();

        if (!className.trim() || !roomName.trim()) {
            setError('Please enter valid string');
            return;
        }

        try {
            const response = await axios.post('http://localhost:7071/api/CreateClassFunction', {
                ClassName: className,
                RoomName: roomName
            });
            console.log(response);

            alert('Create successful !');
            navigate('/');
        }
        catch (error) {
            console.error('Error: ', error)
            setError('An error when create class !')
        }
    };

    return (
        <div className='container mt-5'>
            <h2 className='mb-4'>Create new class</h2>

            {error && <div className='alert alert-danger'>{error}</div>}

            <form onSubmit={handleSubmit}>
                <div className='mb-3'>
                    <label className='form-label'>Class name:</label>
                    <input
                        type='text'
                        className='form-control'
                        value={className}
                        onChange={(e) => setClassName(e.target.value)}
                        placeholder='Enter class name'
                        required />
                </div>
                <div className='mb-3'>
                    <label className='form-label'>Room Name:</label>
                    <input
                        type='text'
                        className='form-control'
                        value={roomName}
                        onChange={(e) => setRoomName(e.target.value)}
                        placeholder='Enter room name'
                        required />
                </div>
                <button type='submit' className='btn btn-primary'>Create</button>
                <button
                    type='button'
                    className='btn btn-secondary ms-2'
                    onClick={() => navigate('/')}>Cancel</button>
            </form>
        </div>
    )
}


export default AddClass;