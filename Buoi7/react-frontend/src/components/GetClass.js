import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';

const ClassList = () => {
    // State để quản lý danh sách lớp học
    const [classes, setClasses] = useState([]); 
    // State để theo dõi trạng thái tải dữ liệu
    const [loading, setLoading] = useState(true); 
    // State để lưu trữ lỗi nếu có
    const [error, setError] = useState(null); 

    // Hàm để lấy danh sách lớp học từ API
    const fetchClasses = async () => {
        try {
            setLoading(true);
            // Điều chỉnh URL để phù hợp với API GetClassFunction của bạn
            const response = await axios.get('http://localhost:7071/api/GetClassFunction');
            console.log('Fetched Classes:', response.data);  // Log dữ liệu để kiểm tra
            setClasses(response.data);
            setError(null);
        } catch (error) {
            console.error('Error fetching classes:', error);
            setError(`Có lỗi xảy ra: ${error.response?.status || '500'} - ${error.response?.data || 'Không thể kết nối với server!'}`);
        } finally {
            setLoading(false);
        }
    };

    // Gọi hàm fetchClasses khi component được render
    useEffect(() => {
        fetchClasses();
    }, []);

    // Hàm xóa lớp học (bạn sẽ phải có API tương ứng)
    const handleDelete = async (classId) => {
        try {
            await axios.delete(`http://localhost:7071/api/DeleteClass/${classId}`);
            alert('Delete class successful!');
            // Tải lại danh sách lớp học sau khi xóa
            fetchClasses();
        } catch (error) {
            console.error('Error deleting class:', error);
            alert('An error when delete class!');
        }
    };

    // Hiển thị thông báo tải 
    if (loading) {
        return <div>Loading...</div>;
    }

    // Hiển thị lỗi nếu có
    if (error) {
        return <div>{error}</div>;
    }

    return (
        <div className="container mt-4">
            {/* Nút thêm lớp học mới */}
            <Link to="/add-class" className="btn btn-primary mb-3">Add class</Link> 

            {classes.length > 0 ? (
                <table className="table table-bordered">
                    <thead>
                        <tr>
                            <th>Class Name</th>
                            <th>Room Name</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        {classes.map(classItem => (
                            <tr key={classItem.id}>
                                <td>{classItem.className || 'Chưa có tên'}</td>
                                <td>{classItem.roomName || 'Chưa có phòng'}</td>
                                <td>
                                    {/* Các nút sửa và xóa */}
                                    <Link 
                                        to={`/edit-class/${classItem.id}`} 
                                        className="btn btn-warning btn-sm me-2"
                                    >
                                        Sửa
                                    </Link>
                                    <button 
                                        className="btn btn-danger btn-sm" 
                                        onClick={() => handleDelete(classItem.id)}
                                    >
                                        Xóa
                                    </button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            ) : (
                <p>Not found any class.</p>
            )}
        </div>
    );
};

export default ClassList;