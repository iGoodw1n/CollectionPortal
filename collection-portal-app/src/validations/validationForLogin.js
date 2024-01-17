import * as Yup from 'yup'

export default Yup.object({
  email: Yup
    .string()
    .email('Incorrect email')
    .required(),
  password: Yup
    .string()
    .required(),
})