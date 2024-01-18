import * as Yup from 'yup'

export default Yup.object({
  name: Yup
    .string()
    .required('Name is required'),
  category: Yup
    .string()
    .required(),
})