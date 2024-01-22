import { useField } from "formik";

const MyDateInput = ({ label, ...props }) => {
  const [field, meta] = useField(props);
  return (
    <div className="d-flex flex-column justify-content-center align-items-center form-group">
      <label className="fs-4 m-2" htmlFor={props.name}>{label}</label>
      <input className="form-control" id={props.name} {...props} {...field} type="date"/>
      {meta.touched && meta.error ? (
        <div className="text-danger">{meta.error}</div>
      ) : null}
    </div>
  )
}

export default MyDateInput