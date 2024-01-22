import { FIELD_TYPE_CHECKBOX, FIELD_TYPE_DATE, FIELD_TYPE_NUMBER, FIELD_TYPE_STRING, FIELD_TYPE_TEXT } from "../constants"

export default function getFieldWithNames(collection) {
  console.log('GetFieldNames ', collection);
  const fieldNames = {}
  for (let index = 1; index <= 3; index++) {
    console.log('i = ', index);
    for (const type of [FIELD_TYPE_TEXT, FIELD_TYPE_STRING, FIELD_TYPE_NUMBER, FIELD_TYPE_DATE, FIELD_TYPE_CHECKBOX]) {
      console.log(`custom${type}${index}State`);
      console.log(collection[`custom${type}${index}State`]);
      if (collection[`custom${type}${index}State`]) {
        fieldNames[`custom${type}${index}`] = {
          name: collection[`custom${type}${index}Name`],
          type
        }
      }
    }
  }
  return fieldNames
}