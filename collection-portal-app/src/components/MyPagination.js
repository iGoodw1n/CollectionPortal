import Pagination from 'react-bootstrap/Pagination';

const MyPagination = ({ pages, onClickHandle, active }) => {
  return (
    <div>
      <Pagination>
        {pages.map(page => (
          <Pagination.Item key={page} active={active === page} onClick={onClickHandle(page)}>{page}</Pagination.Item>
        ))}
      </Pagination>
    </div>
  )
}

export default MyPagination