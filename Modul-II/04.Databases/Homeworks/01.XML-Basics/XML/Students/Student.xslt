<?xml version="1.0"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <head>
        <title>Students</title>
        <style>
         
        </style>
      </head>
      <body>
        <table border="1px">
          <tr>
            <th>Student</th>
            <th>Sex</th>
            <th>Birth Date</th>
            <th>Phone</th>
            <th>Email</th>
            <th>Course</th>
            <th>Specialty</th>
            <th>Faculty Number</th>
            <th>Taken Exams</th>
            <th>Incomng Exams</th>
          </tr>
          <xsl:for-each select="students/student">
            <tr>
              <td>
                <xsl:value-of  select="name"/>
              </td>
              <td>
                <xsl:value-of  select="sex"/>
              </td>
              <td>
                <xsl:value-of  select="birth-date"/>
              </td>
              <td>
                <xsl:value-of  select="phone"/>
              </td>
              <td>
                <xsl:value-of  select="email"/>
              </td>
              <td>
                <xsl:value-of  select="course"/>
              </td>
              <td>
                <xsl:value-of  select="specialty"/>
              </td>
              <td>
                <xsl:value-of  select="faculty-number"/>
              </td>
              <td>
                <xsl:value-of  select="taken-exams/exam/name"/>
                Tutor:
                <xsl:value-of  select="taken-exams/exam/tutor"/>
                Score:
                <xsl:value-of  select="taken-exams/exam/score"/>
              </td>
              <td>
                <xsl:value-of  select="incoming-exams/exam/name"/>
                Date:
                <xsl:value-of  select="incoming-exams/exam/date"/>
                Tutor:
                <xsl:value-of  select="incoming-exams/exam/tutor"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
