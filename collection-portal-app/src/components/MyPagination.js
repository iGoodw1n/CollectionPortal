import Pagination from 'react-bootstrap/Pagination';

const MyPagination = ({ pages, onClickHandle, active }) => {
  return (
    <div>
      <Pagination>
        {[...Array(pages + 1).keys()].slice(1).map(page => (
          <Pagination.Item key={page} active={active === page} onClick={() => onClickHandle(page)}>{page}</Pagination.Item>
        ))}
      </Pagination>
    </div>
  )
}

export default MyPagination