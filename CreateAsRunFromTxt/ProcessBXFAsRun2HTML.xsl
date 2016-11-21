<?xml version="1.0"?>

<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
                xmlns:bxf="http://smpte-ra.org/schemas/2021/2008/BXF" 
                xmlns:msxsl="urn:schemas-microsoft-com:xslt"
                xmlns:user="urn:my-scripts"
                version="1.0">
  <xsl:output method="html" />
  <xsl:param name="utcOffset"/>
  <msxsl:script language="C#" implements-prefix="user">
    <msxsl:assembly name="System.Web" />
    <msxsl:using namespace="System.Web" />
    <![CDATA[
      public string GetDate(string strInDate,string strInTime, int offset)
      {
       string strJustTime = strInDate+" "+strInTime.Substring(0,8);
       DateTime myFirstTime = DateTime.ParseExact(strJustTime,"yyyy-MM-dd HH:mm:ss", null);
       DateTime mySecondTime = myFirstTime.AddHours(-4);
       return String.Format("{0:yyyy-MM-dd}",mySecondTime);
      }
      public string GetTime(string strInDate,string strInTime, int offset)
      {
       string strJustTime = strInTime.Substring(0,8);
       DateTime myFirstTime = DateTime.ParseExact(strJustTime,"HH:mm:ss", null);
       DateTime mySecondTime = myFirstTime.AddHours(-4);
       return String.Format("{0:HH:mm:ss}",mySecondTime) + strInTime.Substring(8,3);
      // return strInTime.Substring(8,3);
      }
    ]]>
  </msxsl:script>
  <xsl:template match="/">
    <HTML>
      <HEAD>
        <TITLE>
          <xsl:value-of select="bxf:BxfMessage/bxf:BxfData/bxf:Schedule/@type"/>
          <xsl:text> Schedule: Channel </xsl:text>
          <xsl:value-of select="bxf:BxfMessage/bxf:BxfData/bxf:Schedule/bxf:Channel/@shortName"/>
          <xsl:text> - </xsl:text>
          <xsl:value-of select="bxf:BxfMessage/bxf:BxfData/bxf:Schedule/@scheduleStart"/>
        </TITLE>
      </HEAD>
      <BODY>
        <Font size="4" face="Calibri" >
          
            <xsl:value-of select="bxf:BxfMessage/bxf:BxfData/bxf:Schedule/@type"/>
            <xsl:text> Schedule: Channel </xsl:text>
            <xsl:value-of select="bxf:BxfMessage/bxf:BxfData/bxf:Schedule/bxf:Channel/@shortName"/>
            <xsl:text> - </xsl:text>
            <xsl:value-of select="bxf:BxfMessage/bxf:BxfData/bxf:Schedule/@scheduleStart"/>
          <xsl:text> Schedule Id: </xsl:text>
          <xsl:value-of select="bxf:BxfMessage/bxf:BxfData/bxf:Schedule/@scheduleId"/>
        </Font>
        <font size="3" face="Calibri">
        <table border="2" cellborder="2" bordercolor="#000000" rules="ALL">

          <thead bgcolor="#EAEEEE">
            <td>Actual Start Date</td>
            <td>Actual Start Time</td>
            <td>HouseNumber</td>
            <td>Actual Duration</td>
            <td>Event Type</td>
            <td>As Run Status</td>
            <td>Event Id</td>
            <td>Billing Reference Code</td>
            <td>Advertiser</td>
            <td>ISCI Code</td>
          </thead>

 
            <xsl:apply-templates select="//bxf:BasicAsRun" />

        </table>
        </font>
      </BODY>
    </HTML>
  </xsl:template>
  
  <xsl:template match="//bxf:BasicAsRun" >
    <tr>
      <xsl:variable name="evType" select="bxf:AsRunDetail/bxf:Type" />
      <xsl:variable name="phType" select="'ProgramHeader'" />
      <xsl:variable name="nonPriType" select="'NonPrimary'" />
      <xsl:variable name="priType" select="'Primary'" />

      <xsl:attribute name ="bgcolor">
        <xsl:choose>
          <xsl:when test="contains($evType,$phType)" >
            <xsl:text>#FFFFC8</xsl:text>
          </xsl:when>
          <xsl:when test="contains($evType,$nonPriType)" >
            <xsl:text>#EAFFFF</xsl:text>
          </xsl:when>
          <xsl:when test="contains($evType,$priType)" >
            <xsl:text>#FEF2CB</xsl:text>
          </xsl:when>
          <xsl:otherwise>
            <xsl:text>#F9F9F9</xsl:text>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:attribute>

      <xsl:variable name ="actualDate" select="bxf:AsRunDetail/bxf:StartDateTime/bxf:SmpteDateTime/@broadcastDate" />
      <xsl:variable name="actualTime" select="bxf:AsRunDetail/bxf:StartDateTime/bxf:SmpteDateTime/bxf:SmpteTimeCode"/>
      <!-- Old Section below -->
      <!--
      <xsl:variable name="localDate" select="usr:convertDate($actualDate, $actualTime, $utcOffset)"/>
      <xsl:variable name="localTime" select="usr:convertTime($actualDate, $actualTime,$utcOffset)"/>
      -->
      <!-- New section with my local date functions -->
      <xsl:variable name="localDate" select="user:GetDate($actualDate,$actualTime,$utcOffset)"/>
      <xsl:variable name="localTime" select="user:GetTime($actualDate,$actualTime,$utcOffset)"/>

      <td>
        <xsl:value-of select="$localDate"/>
      </td>

      <td>
        <xsl:value-of select="$localTime"/>
      </td>

      <td>
        <xsl:value-of select="bxf:Content/bxf:ContentId/bxf:HouseNumber"/>
      </td>

      <td>
          <xsl:value-of select="bxf:AsRunDetail/bxf:Duration/bxf:SmpteDuration/bxf:SmpteTimeCode" />
      </td>

      <td>
          <xsl:value-of select="string($evType)" />
      </td>

      <td>
        <xsl:value-of select="bxf:AsRunDetail/bxf:Status" />
      </td>
     
      <td>
        <xsl:value-of select="bxf:AsRunEventId/bxf:EventId"/>
      </td>

      <td>
        <xsl:value-of select="bxf:AsRunEventId/bxf:BillingReferenceCode"/>
      </td>

      <td>
        <xsl:value-of select="bxf:Content/bxf:Name"/>
      </td>
      <td>
        <xsl:value-of select="bxf:Content/bxf:ContentId/bxf:AlternateId"/>
      </td>
      
      
    </tr>
  </xsl:template>

  
</xsl:stylesheet>