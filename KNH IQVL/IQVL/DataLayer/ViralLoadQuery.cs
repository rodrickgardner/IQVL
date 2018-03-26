using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQVL.DataLayer
{ 

   

    public static class ViralLoadQuery
    {

        public static string VLKHHLabList = @"Open symmetric key Key_CTC decryption by password='ttwbvXWpqb5WOLfLrBgisw=='

select convert(varchar(100),
decryptbykey(l.firstname)) + ' ' + convert(varchar(100),decryptbykey(l.MiddleName)) + ' ' +  convert(varchar(100),decryptbykey(l.LastName)) as FullName,CAST(ISNULL(a.LabID,'0') as varchar(max)) as 
 [SpecimenLabID],CASE WHEN l.Patient_Number is null then cast(l.PatientIPNo as varchar(max)) else cast(l.Patient_Number as varchar(max)) end as PatientIpNo,
 i.FacilityName,CASE WHEN i.FacilityName like '%Patient in Transit%' THEN  '999990'  else '13023' end as MFLCode,
 (Select case when l.Sex='16'   then '1' when l.Sex='17' then '2' else '0' end) as Sex,l.DOB,CONVERT(int,ROUND(DATEDIFF(hour,l.DOB,GETDATE())/8766.0,0)) Age,
 case  replace(k.LabName,' ','') when 'ViralLoad' then '1' END as [Sample Type],CAST(Convert(Varchar(max),h.Date_Sample_Collected,106) AS DATE) as [Date Collected],
 '0' as [Current Regimen],'0' as [Current ART Start Date] ,'0' as [Date Started on ART], (select case when vl.JustificationID='7' then '9' when vl.JustificationID='8' then '10' when vl.JustificationID is null then '0'  else vl.JustificationID end) as Justification,GETDATE() 
 as [Date Received]
 from ord_PatientLabOrder a

 inner join IQCare.dbo.dtl_PatientLabResults b on a.labid = b.labid

LEFT join IQCare.dbo.dtl_CustomField_Laboratory  h on h.LabID=a.LabID
left join  IQCare.dbo.mst_Facility i on i.FacilityID =a.LocationID


left join IQCare.dbo.ord_Visit j on j.Visit_Id = a.VisitId
left join IQCare.dbo.mst_Patient l on l.Ptn_Pk=a.Ptn_pk
left join IQCare.dbo.dtl_VLJustification vl on  b.LabID=vl.LabID 
left join IQCare.dbo.mst_Decode dc on dc.ID=l.Sex

--inner join IQCare.dbo.mst_Patient l on l.PatientIPNo=a.Ptn_pk

left join IQCare.dbo.mst_LabTest k on k.LabTestID =b.LabTestID
where K.LabName ='Viral Load'  
and b.TestResults IS NULL  and a.LabId=@LabOrderId";
        public static string VLKNHAllList = @"Open symmetric key Key_CTC decryption by password='ttwbvXWpqb5WOLfLrBgisw=='

select convert(varchar(100),
decryptbykey(l.firstname)) + ' ' + convert(varchar(100),decryptbykey(l.MiddleName)) + ' ' +  convert(varchar(100),decryptbykey(l.LastName)) as FullName,CAST(ISNULL(a.LabID,'0') as varchar(max)) as 
 [SpecimenLabID],CASE WHEN l.Patient_Number is null then cast(l.PatientIPNo as varchar(max)) else cast(l.Patient_Number as varchar(max)) end as PatientIpNo,
 i.FacilityName,CASE WHEN i.FacilityName like '%Patient in Transit%' THEN  '999990'  else '13023' end as MFLCode,
 (Select case when l.Sex='16'   then '1' when l.Sex='17' then '2' else '0' end) as Sex,l.DOB,CONVERT(int,ROUND(DATEDIFF(hour,l.DOB,GETDATE())/8766.0,0)) Age,
 case  replace(k.LabName,' ','') when 'ViralLoad' then '1' END as [Sample Type],CAST(Convert(Varchar(max),h.Date_Sample_Collected,106) AS DATE) as [Date Collected],
 '0' as [Current Regimen],'0' as [Current ART Start Date] ,'0' as [Date Started on ART], (select case when vl.JustificationID='7' then '9' when vl.JustificationID='8' then '10' when vl.JustificationID is null then '0'  else vl.JustificationID end) as Justification,GETDATE() 
 as [Date Received]
 from ord_PatientLabOrder a

 left join IQCare.dbo.dtl_PatientLabResults b on a.labid = b.labid

left join IQCare.dbo.dtl_CustomField_Laboratory  h on h.LabID=a.LabID
left join  IQCare.dbo.mst_Facility i on i.FacilityID =a.LocationID


left join IQCare.dbo.ord_Visit j on j.Visit_Id = a.VisitId
left join IQCare.dbo.mst_Patient l on l.Ptn_Pk=a.Ptn_pk
left join IQCare.dbo.dtl_VLJustification vl on  b.LabID=vl.LabID 
left join IQCare.dbo.mst_Decode dc on dc.ID=l.Sex

--inner join IQCare.dbo.mst_Patient l on l.PatientIPNo=a.Ptn_pk

left join IQCare.dbo.mst_LabTest k on k.LabTestID =b.LabTestID
where K.LabName ='Viral Load'  
and b.TestResults IS NULL  and a.Ptn_pk=Cast('@ptn_pk' as int)";

        public static string ViralloadAllKNHResults = @"Open symmetric key Key_CTC decryption by password='ttwbvXWpqb5WOLfLrBgisw=='

select convert(varchar(100),
decryptbykey(l.firstname)) + ' ' + convert(varchar(100),decryptbykey(l.MiddleName)) + ' ' +  convert(varchar(100),decryptbykey(l.LastName)) as FullName,CAST(ISNULL(a.LabID,'0') as varchar(max)) as 
 [SpecimenLabID],CASE WHEN l.Patient_Number is null then CAST(l.PatientIPNo as varchar(max)) else Cast(l.Patient_Number as varchar(max)) end as PatientIpNo,
 i.FacilityName,CASE WHEN i.FacilityName like '%Patient in Transit%' THEN  '999990'  else '13023' end as MFLCode,
 (Select case when l.Sex='16'   then '1' when l.Sex='17' then '2' else '0' end) as Sex,l.DOB,CONVERT(int,ROUND(DATEDIFF(hour,l.DOB,GETDATE())/8766.0,0)) Age,
 case  replace(k.LabName,' ','') when 'ViralLoad' then '1' END as [Sample Type],CAST(Convert(Varchar(max),h.Date_Sample_Collected,106) AS DATE) as [Date Collected],
 '0' as [Current Regimen],'0' as [Current ART Start Date] ,'0' as [Date Started on ART], (select case when vl.JustificationID='7' then '9' when vl.JustificationID='8' then '10' when vl.JustificationID is null then '0'  else vl.JustificationID end) as Justification,GETDATE() 
 as [Date Received],b.TestResults
 from ord_PatientLabOrder a

 left join IQCare.dbo.dtl_PatientLabResults b on a.labid = b.labid

left join IQCare.dbo.dtl_CustomField_Laboratory  h on h.LabID=a.LabID
left join  IQCare.dbo.mst_Facility i on i.FacilityID =a.LocationID


left join IQCare.dbo.ord_Visit j on j.Visit_Id = a.VisitId
left join IQCare.dbo.mst_Patient l on l.Ptn_Pk=a.Ptn_pk
left join IQCare.dbo.dtl_VLJustification vl on  b.LabID=vl.LabID 
left join IQCare.dbo.mst_Decode dc on dc.ID=l.Sex

--inner join IQCare.dbo.mst_Patient l on l.PatientIPNo=a.Ptn_pk

left join IQCare.dbo.mst_LabTest k on k.LabTestID =b.LabTestID
where K.LabName ='Viral Load'  

and (h.Date_Sample_collected  between cast('@fromdate' as datetime) and cast('@todate'  as datetime))
";
     public static string ViralLoadWithoutResultsKNH = @"Open symmetric key Key_CTC decryption by password='ttwbvXWpqb5WOLfLrBgisw=='

select convert(varchar(100),
decryptbykey(l.firstname)) + ' ' + convert(varchar(100),decryptbykey(l.MiddleName)) + ' ' +  convert(varchar(100),decryptbykey(l.LastName)) as FullName,CAST(ISNULL(a.LabID,'0') as varchar(max)) as 
 [SpecimenLabID],CASE WHEN l.Patient_Number is null then cast(l.PatientIPNo as varchar(max)) else cast(l.Patient_Number as varchar(max)) end as PatientIpNo,
 i.FacilityName,CASE WHEN i.FacilityName like '%Patient in Transit%' THEN  '999990'  else '13023' end as MFLCode,
 (Select case when l.Sex='16'   then '1' when l.Sex='17' then '2' else '0' end) as Sex,l.DOB,CONVERT(int,ROUND(DATEDIFF(hour,l.DOB,GETDATE())/8766.0,0)) Age,
 case  replace(k.LabName,' ','') when 'ViralLoad' then '1' END as [Sample Type],CAST(Convert(Varchar(max),h.Date_Sample_Collected,106) AS DATE) as [Date Collected],
 '0' as [Current Regimen],'0' as [Current ART Start Date] ,'0' as [Date Started on ART], (select case when vl.JustificationID='7' then '9' when vl.JustificationID='8' then '10' when vl.JustificationID is null then '0'  else vl.JustificationID end) as Justification,GETDATE() 
 as [Date Received]
 from ord_PatientLabOrder a

 inner join IQCare.dbo.dtl_PatientLabResults b on a.labid = b.labid

left join IQCare.dbo.dtl_CustomField_Laboratory  h on h.LabID=a.LabID
left join  IQCare.dbo.mst_Facility i on i.FacilityID =a.LocationID


inner join IQCare.dbo.ord_Visit j on j.Visit_Id = a.VisitId
left join IQCare.dbo.mst_Patient l on l.Ptn_Pk=a.Ptn_pk
left join IQCare.dbo.dtl_VLJustification vl on  b.LabID=vl.LabID 
left join IQCare.dbo.mst_Decode dc on dc.ID=l.Sex

--inner join IQCare.dbo.mst_Patient l on l.PatientIPNo=a.Ptn_pk

left join IQCare.dbo.mst_LabTest k on k.LabTestID =b.LabTestID
where K.LabName ='Viral Load'  

and (h.Date_Sample_collected  between cast('@fromdate' as datetime) and cast('@todate'  as datetime))
and b.TestResults IS NULL";
        public static string VlList = @"
Open symmetric key Key_CTC decryption by password='ttwbvXWpqb5WOLfLrBgisw=='
select
convert(varchar(100),decryptbykey(pt.firstname)) + ' ' + convert(varchar(100),decryptbykey(pt.MiddleName)) + ' ' +  convert(varchar(100),decryptbykey(pt.LastName)) as FullName,
plabs.LabId,
CASE WHEN pt.PatientEnrollmentID IS not null and len(pt.PatientEnrollmentId) > 0 then pt.PatientEnrollmentId
WHEN pt.PatientEnrollmentID is null and len (pt.PatientEnrollmentId) < 0 and len(pt.PatientClinicID) > 0   then pt.PatientClinicID
else pt.PatientClinicID end   as ClientIpNo,
f.FacilityName,f.SatelliteID as MFLCode, CASE dc.Name
    WHEN 'Female' THEN '2'
    WHEN 'Male' THEN '1'
  END AS [Sex]
  , pt.DOB
  , DATEDIFF(HOUR, pt.DOB, GETDATE()) / 8766 AS Age
   ,'1' as SampleType
,plabs.OrderedbyDate as [DateofRequest]
,CASE WHEN plabs.ReceivedDatetime is null then plabs.OrderedbyDate else plabs.ReceivedDatetime  end AS[DateSampleCollected] 
, CASE 
    WHEN
    arv.regimen LIKE   '%3TC+EFV+TDF' THEN '4'
    WHEN  
	arv.regimen LIKE '%EFV/3TC/TDF' THEN '4'
	when
	 arv.regimen LIKE
	 '%3TC/TDF/EFV' then '4'
    WHEN
	
	arv.regimen LIKE '%3TC+AZT+NVP' THEN '1'
	WHEN 
	arv.regimen LIKE'%AZT/3TC/NVP' then  '1'
    WHEN 
	arv.regimen LIKE '%NVP/3TC/AZT' THEN '1'
	WHEN
	arv.regimen like '%3TC/NVP/AZT%' then '1'
    WHEN 
	arv.regimen LIKE '%3TC+AZT+EFV' THEN '2'
	when 
	arv.regimen like '%3TC/AZT/EFV%' then '2'
	WHEN 
	arv.regimen LIKE '%AZT/3TC/EFV' then '2'
    WHEN 
	 arv.regimen LIKE '%EFV/3TC/AZT' THEN '2'
	WHEN 
	arv.regimen LIKE '%3TC/NVP/TDF' then '3'
	WHEN 
	arv.regimen LIKE '%3TC/TDF/NVP%' then '3'
    WHEN 
	arv.regimen LIKE '%3TC+NVP+TDF' THEN '3'
    WHEN 
	arv.regimen LIKE '%NVP/3TC/TDF' THEN '3'
    WHEN 
	 arv.regimen LIKE '%3TC+AZT+LPV/r' THEN '5'
	WHEN  
   arv.regimen LIKE 	'%3TC/AZT/LOPr'   THEN '5'
	WHEN 
   arv.regimen LIKE 	'%3TC/AZT/LPV/r' then '5'
	WHEN 
  arv.regimen LIKE	'%LOPr/3TC/AZT'  then '5'
    WHEN 
 arv.regimen LIKE	'%LPVr/3TC/AZT' THEN '5'
    WHEN  
arv.regimen LIKE	'%3TC+ABC+AZT' THEN '6'
    WHEN 
   arv.regimen LIKE	'%3TC/ABC/AZT' then '6'
    WHEN 
	arv.regimen LIKE '%ABC/3TC/AZT' THEN '6'
    WHEN 
	arv.regimen LIKE '%3TC+LPVr+TDF' THEN '7'
	WHEN arv.regimen like '%3TC/TDF/LOPr%' then '7'
	WHEN arv.regimen like '%3TC/LOPr/TDF%' then '7'
    WHEN 
	 arv.regimen LIKE  '%LOPr/3TC/TDF%' THEN '7'
    WHEN 
	 arv.regimen LIKE  '%LPVr/3TC/TDF%' THEN '7'
    WHEN 
	arv.regimen LIKE
	'%3TC+ATVr+AZT%' THEN '8'
    WHEN 
     arv.regimen LIKE	'%ATVr/3TC/AZT%' THEN '8'
    WHEN 
     arv.regimen LIKE	'%3TC+ATVr+TDF%' THEN '9'
    WHEN 
	 arv.regimen LIKE  '%ATVr/3TC/TDF%' THEN '9'
    WHEN 
    arv.regimen LIKE 	'%3TC+ABC+ATVr%' THEN '10'
	WHEN  
    arv.regimen LIKE 	'%3TC/ABC/ATVr%' then'10'
    WHEN 
	 arv.regimen LIKE  '%ATVr/3TC/ABC%' THEN '10'
    WHEN 
	arv.regimen LIKE  '%3TC+ABC+NVP%' THEN '11'
	WHEN 
	arv.regimen LIKE  '%3TC/ABC/NVP%' then '11'
	WHEN 
	  arv.regimen LIKE '%ABC/3TC/NVP%' then '11'
    WHEN  
	arv.regimen LIKE '%NVP/3TC/ABC%' THEN '11'
    WHEN 
	arv.regimen LIKE  '%3TC+ABC+EFV%' THEN '12'
	WHEN  
	arv.regimen LIKE '%3TC/ABC/EFV%' then '12'
	WHEN  
	arv.regimen LIKE '%ABC/3TC/EFV%' then '12'
    WHEN 
	arv.regimen LIKE '%EFV/3TC/ABC%' THEN '12'

    WHEN arv.regimen LIKE  '%3TC+ABC+LPVr%' THEN '13'
	WHEN arv.regimen LIKE '%3TC/ABC/LOPr%' then '13'
	WHEN arv.regimen LIKE '%LOPr/ABC/3TC%' then '13'
    WHEN arv.regimen LIKE '%LPVr/3TC/ABC%' THEN '13'
    WHEN arv.regimen LIKE 'Other' THEN '14'
    WHEN  arv.regimen LIKE 'None' THEN '15'
    WHEN arv.regimen like  NULL  THEN '16'
    WHEN arv.regimen LIKE '%No Data' THEN '16'
	ELSE '0'
  END AS [Current Regimen],
  arv.dispenseDate[Current ART Start Date],
  arvinitial.dispenseDate AS[Date Started On ART],
 CASE WHEN  plabs.Justification is null then '0' else plabs.Justification end  AS Justification,
  GETDATE() AS DateReceived

from(
select a.LabID, a.Ptn_pk, a.LocationID, a.OrderedByName, a.OrderedByDate, a.ReportedByName, a.ReportedByDate, a.CheckedByName, a.CheckedByDate, a.PreClinicLabDate,CAST(Convert(nvarchar(10),lsp.ReceivedDatetime,101) as datetime) as ReceivedDatetime,
 a.LabPeriod,  b.Justification,


b.LabTestID, c.SubTestId, b.TestResults, b.TestResults1, b.TestResultId, b.Financed,

c.subtestname[SubTestName], d.LabTypeID 'LabTypeID', d.LabName, b.Units, e.name as UnitName,

f.MinBoundaryValue, f.MaxBoundaryValue, a.LabNumber

from ord_PatientlabOrder a
left join mst_LabSpecimen  lsp   on lsp.LabID=a.LabID

inner join dtl_PatientLabResults b on a.labid = b.labid

left outer join mst_Decode e on e.Id= b.Units


left outer join lnk_labValue f on  f.UnitId= b.units and f.SubTestId= b.ParameterId

left outer join lnk_testParameter c on c.subtestid= b.parameterId

inner join mst_labtest d on c.testid= d.labtestid
where d.LabName like '%Viral%'
and (a.DeleteFlag='0' or a.DeleteFlag is null))plabs
inner join mst_patient pt on pt.Ptn_pk=plabs.Ptn_Pk
LEFT JOIN mst_Facility f
  ON f.FacilityID = pt.LocationID
left join mst_Decode dc on dc.ID=pt.Sex
left join(
select arvlist.Ptn_Pk, arvlist.dispenseDate,
arvlist.regimen from(select arv.Ptn_Pk, arv.regimen, arv.dispenseDate, ROW_NUMBER() OVER(partition by arv.Ptn_pk order by arv.VisitID desc) as rownum from(Select Distinct
   m.Ptn_pk,
   a.VisitID,
   a.DispensedByDate dispenseDate,

   Case When g.RegimenType = '' Then f.DrugName Else g.RegimenType End As regimen,
    SubString(g.RegimenType, 0, 4) [1],
Case
When CharIndex('/', g.RegimenType) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType) + 1, 3) End As[2],
Case
When CharIndex('/', g.RegimenType, 6) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType, 6) + 1, 3) Else Null End As[3],
Case
When CharIndex('/', g.RegimenType, 10) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType, 10) + 1, 3) Else Null End As[4],
Case
When CharIndex('/', g.RegimenType, 14) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType, 14) + 1, 3) Else Null End As[5],
--Max(b.Duration) duration,
h.Name Provider,
j.Name regimenLine,
i.Name treatmentType



From mst_Patient m
LEFT Join ord_PatientPharmacyOrder a On m.Ptn_Pk = a.Ptn_pk
LEFT join dtl_PatientPharmacyOrder b On a.ptn_pharmacy_pk = b.ptn_pharmacy_pk
LEFT join lnk_DrugGeneric c on b.Drug_Pk = c.Drug_pk
LEFT join lnk_DrugTypeGeneric d on c.GenericID = d.GenericId
LEFT join mst_DrugType e on d.DrugTypeId = e.DrugTypeID
LEFT join mst_Drug f on b.Drug_Pk = f.Drug_pk
LEFT Join dtl_RegimenMap g On a.VisitID = g.Visit_Pk
LEFT Join mst_Provider h On a.ProviderID = h.ID
LEFT Join mst_Decode i On a.ProgID = i.ID
LEFT Join mst_RegimenLine j On a.RegimenLine = j.ID

Where
m.RegistrationDate <= a.DispensedByDate

AND e.DrugTypeName = 'ARV Medication'
AND(a.DeleteFlag = 0 OR a.DeleteFlag IS NULL)
AND(m.DeleteFlag = 0 OR m.DeleteFlag IS NULL)
)arv )arvlist where arvlist.rownum='1')arv on arv.Ptn_Pk=pt.Ptn_Pk
left join(
select arvlist.Ptn_Pk, arvlist.dispenseDate,
arvlist.regimen from(select arv.Ptn_Pk, arv.regimen, arv.dispenseDate, ROW_NUMBER() OVER(partition by arv.Ptn_pk order by arv.VisitID asc) as rownum from(Select Distinct
   m.Ptn_pk,
   a.VisitID,
   a.DispensedByDate dispenseDate,

   Case When g.RegimenType = '' Then f.DrugName Else g.RegimenType End As regimen,
    SubString(g.RegimenType, 0, 4) [1],
Case
When CharIndex('/', g.RegimenType) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType) + 1, 3) End As[2],
Case
When CharIndex('/', g.RegimenType, 6) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType, 6) + 1, 3) Else Null End As[3],
Case
When CharIndex('/', g.RegimenType, 10) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType, 10) + 1, 3) Else Null End As[4],
Case
When CharIndex('/', g.RegimenType, 14) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType, 14) + 1, 3) Else Null End As[5],
--Max(b.Duration) duration,
h.Name Provider,
j.Name regimenLine,
i.Name treatmentType



From mst_Patient m
LEFT Join ord_PatientPharmacyOrder a On m.Ptn_Pk = a.Ptn_pk
LEFT join dtl_PatientPharmacyOrder b On a.ptn_pharmacy_pk = b.ptn_pharmacy_pk
LEFT join lnk_DrugGeneric c on b.Drug_Pk = c.Drug_pk
LEFT join lnk_DrugTypeGeneric d on c.GenericID = d.GenericId
LEFT join mst_DrugType e on d.DrugTypeId = e.DrugTypeID
LEFT join mst_Drug f on b.Drug_Pk = f.Drug_pk
LEFT Join dtl_RegimenMap g On a.VisitID = g.Visit_Pk
LEFT Join mst_Provider h On a.ProviderID = h.ID
LEFT Join mst_Decode i On a.ProgID = i.ID
LEFT Join mst_RegimenLine j On a.RegimenLine = j.ID

Where
m.RegistrationDate <= a.DispensedByDate

AND e.DrugTypeName = 'ARV Medication'
AND(a.DeleteFlag = 0 OR a.DeleteFlag IS NULL)
AND(m.DeleteFlag = 0 OR m.DeleteFlag IS NULL)
)arv )arvlist where arvlist.rownum='1')arvinitial on arvinitial.Ptn_Pk=pt.Ptn_Pk
where plabs.TestResults is null and pt.Ptn_pk=Cast('@ptn_pk' as int);

";
      

        public static string VLWithoutResults = @"
Open symmetric key Key_CTC decryption by password='ttwbvXWpqb5WOLfLrBgisw=='
select
convert(varchar(100),decryptbykey(pt.firstname)) + ' ' + convert(varchar(100),decryptbykey(pt.MiddleName)) + ' ' +  convert(varchar(100),decryptbykey(pt.LastName)) as FullName,
plabs.LabId,
CASE WHEN pt.PatientEnrollmentID IS not null and len(pt.PatientEnrollmentId) > 0 then pt.PatientEnrollmentId
WHEN pt.PatientEnrollmentID is null and len (pt.PatientEnrollmentId) < 0 and len(pt.PatientClinicID) > 0   then pt.PatientClinicID
else pt.PatientClinicID end   as ClientIpNo,
f.FacilityName,f.SatelliteID as MFLCode, CASE dc.Name
    WHEN 'Female' THEN '2'
    WHEN 'Male' THEN '1'
  END AS [Sex]
  , pt.DOB
  , DATEDIFF(HOUR, pt.DOB, GETDATE()) / 8766 AS Age
   ,'1' as SampleType
,plabs.OrderedbyDate as [DateofRequest]
  ,CASE WHEN plabs.ReceivedDatetime is null then plabs.OrderedbyDate else plabs.ReceivedDatetime  end AS[DateSampleCollected] 
  ,CASE 
    WHEN
    arv.regimen LIKE   '%3TC+EFV+TDF' THEN '4'
    WHEN  
	arv.regimen LIKE '%EFV/3TC/TDF' THEN '4'
	when
	 arv.regimen LIKE
	 '%3TC/TDF/EFV' then '4'
    WHEN
	
	arv.regimen LIKE '%3TC+AZT+NVP' THEN '1'
	WHEN 
	arv.regimen LIKE'%AZT/3TC/NVP' then  '1'
    WHEN 
	arv.regimen LIKE '%NVP/3TC/AZT' THEN '1'
	WHEN
	arv.regimen like '%3TC/NVP/AZT%' then '1'
    WHEN 
	arv.regimen LIKE '%3TC+AZT+EFV' THEN '2'
	when 
	arv.regimen like '%3TC/AZT/EFV%' then '2'
	WHEN 
	arv.regimen LIKE '%AZT/3TC/EFV' then '2'
    WHEN 
	 arv.regimen LIKE '%EFV/3TC/AZT' THEN '2'
	WHEN 
	arv.regimen LIKE '%3TC/NVP/TDF' then '3'
	WHEN 
	arv.regimen LIKE '%3TC/TDF/NVP%' then '3'
    WHEN 
	arv.regimen LIKE '%3TC+NVP+TDF' THEN '3'
    WHEN 
	arv.regimen LIKE '%NVP/3TC/TDF' THEN '3'
    WHEN 
	 arv.regimen LIKE '%3TC+AZT+LPV/r' THEN '5'
	WHEN  
   arv.regimen LIKE 	'%3TC/AZT/LOPr'   THEN '5'
	WHEN 
   arv.regimen LIKE 	'%3TC/AZT/LPV/r' then '5'
	WHEN 
  arv.regimen LIKE	'%LOPr/3TC/AZT'  then '5'
    WHEN 
 arv.regimen LIKE	'%LPVr/3TC/AZT' THEN '5'
    WHEN  
arv.regimen LIKE	'%3TC+ABC+AZT' THEN '6'
    WHEN 
   arv.regimen LIKE	'%3TC/ABC/AZT' then '6'
    WHEN 
	arv.regimen LIKE '%ABC/3TC/AZT' THEN '6'
    WHEN 
	arv.regimen LIKE '%3TC+LPVr+TDF' THEN '7'
	WHEN arv.regimen like '%3TC/TDF/LOPr%' then '7'
	WHEN arv.regimen like '%3TC/LOPr/TDF%' then '7'
    WHEN 
	 arv.regimen LIKE  '%LOPr/3TC/TDF%' THEN '7'
    WHEN 
	 arv.regimen LIKE  '%LPVr/3TC/TDF%' THEN '7'
    WHEN 
	arv.regimen LIKE
	'%3TC+ATVr+AZT%' THEN '8'
    WHEN 
     arv.regimen LIKE	'%ATVr/3TC/AZT%' THEN '8'
    WHEN 
     arv.regimen LIKE	'%3TC+ATVr+TDF%' THEN '9'
    WHEN 
	 arv.regimen LIKE  '%ATVr/3TC/TDF%' THEN '9'
    WHEN 
    arv.regimen LIKE 	'%3TC+ABC+ATVr%' THEN '10'
	WHEN  
    arv.regimen LIKE 	'%3TC/ABC/ATVr%' then'10'
    WHEN 
	 arv.regimen LIKE  '%ATVr/3TC/ABC%' THEN '10'
    WHEN 
	arv.regimen LIKE  '%3TC+ABC+NVP%' THEN '11'
	WHEN 
	arv.regimen LIKE  '%3TC/ABC/NVP%' then '11'
	WHEN 
	  arv.regimen LIKE '%ABC/3TC/NVP%' then '11'
    WHEN  
	arv.regimen LIKE '%NVP/3TC/ABC%' THEN '11'
    WHEN 
	arv.regimen LIKE  '%3TC+ABC+EFV%' THEN '12'
	WHEN  
	arv.regimen LIKE '%3TC/ABC/EFV%' then '12'
	WHEN  
	arv.regimen LIKE '%ABC/3TC/EFV%' then '12'
    WHEN 
	arv.regimen LIKE '%EFV/3TC/ABC%' THEN '12'

    WHEN arv.regimen LIKE  '%3TC+ABC+LPVr%' THEN '13'
	WHEN arv.regimen LIKE '%3TC/ABC/LOPr%' then '13'
	WHEN arv.regimen LIKE '%LOPr/ABC/3TC%' then '13'
    WHEN arv.regimen LIKE '%LPVr/3TC/ABC%' THEN '13'
    WHEN arv.regimen LIKE 'Other' THEN '14'
    WHEN  arv.regimen LIKE 'None' THEN '15'
    WHEN arv.regimen like  NULL  THEN '16'
    WHEN arv.regimen LIKE '%No Data' THEN '16'
	ELSE '0'
  END AS [Current Regimen],
  arv.dispenseDate[Current ART Start Date],
  arvinitial.dispenseDate AS[Date Started On ART],
 CASE WHEN  plabs.Justification is null then '0' else plabs.Justification end  AS Justification,
  GETDATE() AS DateReceived

from(
select a.LabID, a.Ptn_pk, a.LocationID, a.OrderedByName, a.OrderedByDate, a.ReportedByName, a.ReportedByDate, a.CheckedByName, a.CheckedByDate, a.PreClinicLabDate,CAST(Convert(nvarchar(10),lsp.ReceivedDatetime,101) as datetime) as ReceivedDatetime,
 a.LabPeriod,  b.Justification,


b.LabTestID, c.SubTestId, b.TestResults, b.TestResults1, b.TestResultId, b.Financed,

c.subtestname[SubTestName], d.LabTypeID 'LabTypeID', d.LabName, b.Units, e.name as UnitName,

f.MinBoundaryValue, f.MaxBoundaryValue, a.LabNumber

from ord_PatientlabOrder a
left join mst_LabSpecimen  lsp   on lsp.LabID=a.LabID

inner join dtl_PatientLabResults b on a.labid = b.labid

left outer join mst_Decode e on e.Id= b.Units


left outer join lnk_labValue f on  f.UnitId= b.units and f.SubTestId= b.ParameterId

left outer join lnk_testParameter c on c.subtestid= b.parameterId

inner join mst_labtest d on c.testid= d.labtestid
where d.LabName like '%Viral%' and (a.DeleteFlag='0' or a.DeleteFlag is null))plabs
inner join mst_patient pt on pt.Ptn_pk=plabs.Ptn_Pk
LEFT JOIN mst_Facility f
  ON f.FacilityID = pt.LocationID
left join mst_Decode dc on dc.ID=pt.Sex
left join(
select arvlist.Ptn_Pk, arvlist.dispenseDate,
arvlist.regimen from(select arv.Ptn_Pk, arv.regimen, arv.dispenseDate, ROW_NUMBER() OVER(partition by arv.Ptn_pk order by arv.VisitID desc) as rownum from(Select Distinct
   m.Ptn_pk,
   a.VisitID,
   a.DispensedByDate dispenseDate,

   Case When g.RegimenType = '' Then f.DrugName Else g.RegimenType End As regimen,
    SubString(g.RegimenType, 0, 4) [1],
Case
When CharIndex('/', g.RegimenType) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType) + 1, 3) End As[2],
Case
When CharIndex('/', g.RegimenType, 6) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType, 6) + 1, 3) Else Null End As[3],
Case
When CharIndex('/', g.RegimenType, 10) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType, 10) + 1, 3) Else Null End As[4],
Case
When CharIndex('/', g.RegimenType, 14) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType, 14) + 1, 3) Else Null End As[5],
--Max(b.Duration) duration,
h.Name Provider,
j.Name regimenLine,
i.Name treatmentType



From mst_Patient m
LEFT Join ord_PatientPharmacyOrder a On m.Ptn_Pk = a.Ptn_pk
LEFT join dtl_PatientPharmacyOrder b On a.ptn_pharmacy_pk = b.ptn_pharmacy_pk
LEFT join lnk_DrugGeneric c on b.Drug_Pk = c.Drug_pk
LEFT join lnk_DrugTypeGeneric d on c.GenericID = d.GenericId
LEFT join mst_DrugType e on d.DrugTypeId = e.DrugTypeID
LEFT join mst_Drug f on b.Drug_Pk = f.Drug_pk
LEFT Join dtl_RegimenMap g On a.VisitID = g.Visit_Pk
LEFT Join mst_Provider h On a.ProviderID = h.ID
LEFT Join mst_Decode i On a.ProgID = i.ID
LEFT Join mst_RegimenLine j On a.RegimenLine = j.ID

Where
m.RegistrationDate <= a.DispensedByDate

AND e.DrugTypeName = 'ARV Medication'
AND(a.DeleteFlag = 0 OR a.DeleteFlag IS NULL)
AND(m.DeleteFlag = 0 OR m.DeleteFlag IS NULL)
)arv )arvlist where arvlist.rownum='1')arv on arv.Ptn_Pk=pt.Ptn_Pk
left join(
select arvlist.Ptn_Pk, arvlist.dispenseDate,
arvlist.regimen from(select arv.Ptn_Pk, arv.regimen, arv.dispenseDate, ROW_NUMBER() OVER(partition by arv.Ptn_pk order by arv.VisitID asc) as rownum from(Select Distinct
   m.Ptn_pk,
   a.VisitID,
   a.DispensedByDate dispenseDate,

   Case When g.RegimenType = '' Then f.DrugName Else g.RegimenType End As regimen,
    SubString(g.RegimenType, 0, 4) [1],
Case
When CharIndex('/', g.RegimenType) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType) + 1, 3) End As[2],
Case
When CharIndex('/', g.RegimenType, 6) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType, 6) + 1, 3) Else Null End As[3],
Case
When CharIndex('/', g.RegimenType, 10) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType, 10) + 1, 3) Else Null End As[4],
Case
When CharIndex('/', g.RegimenType, 14) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType, 14) + 1, 3) Else Null End As[5],
--Max(b.Duration) duration,
h.Name Provider,
j.Name regimenLine,
i.Name treatmentType



From mst_Patient m
LEFT Join ord_PatientPharmacyOrder a On m.Ptn_Pk = a.Ptn_pk
LEFT join dtl_PatientPharmacyOrder b On a.ptn_pharmacy_pk = b.ptn_pharmacy_pk
LEFT join lnk_DrugGeneric c on b.Drug_Pk = c.Drug_pk
LEFT join lnk_DrugTypeGeneric d on c.GenericID = d.GenericId
LEFT join mst_DrugType e on d.DrugTypeId = e.DrugTypeID
LEFT join mst_Drug f on b.Drug_Pk = f.Drug_pk
LEFT Join dtl_RegimenMap g On a.VisitID = g.Visit_Pk
LEFT Join mst_Provider h On a.ProviderID = h.ID
LEFT Join mst_Decode i On a.ProgID = i.ID
LEFT Join mst_RegimenLine j On a.RegimenLine = j.ID

Where
m.RegistrationDate <= a.DispensedByDate

AND e.DrugTypeName = 'ARV Medication'
AND(a.DeleteFlag = 0 OR a.DeleteFlag IS NULL)
AND(m.DeleteFlag = 0 OR m.DeleteFlag IS NULL)
)arv )arvlist where arvlist.rownum='1')arvinitial on arvinitial.Ptn_Pk=pt.Ptn_Pk
where plabs.TestResults is null and plabs.OrderedbyDate  between cast('@fromdate' as datetime) and cast('@todate'  as datetime)
and plabs.TestResultId is null

";
        public static string VlAllResults = @"
Open symmetric key Key_CTC decryption by password='ttwbvXWpqb5WOLfLrBgisw=='
select 
convert(varchar(100),decryptbykey(pt.firstname)) + ' ' + convert(varchar(100),decryptbykey(pt.MiddleName)) + ' ' +  convert(varchar(100),decryptbykey(pt.LastName)) as FullName,
 plabs.LabId,
CASE WHEN pt.PatientEnrollmentID IS not null and len(pt.PatientEnrollmentId) > 0 then pt.PatientEnrollmentId
WHEN pt.PatientEnrollmentID is null and len (pt.PatientEnrollmentId) < 0 and len(pt.PatientClinicID) > 0   then pt.PatientClinicID
else pt.PatientClinicID end   as ClientIpNo,
f.FacilityName,f.SatelliteID as MFLCode, CASE dc.Name
    WHEN 'Female' THEN '2'
    WHEN 'Male' THEN '1'
  END AS [Sex]
  ,pt.DOB
  ,DATEDIFF(HOUR, pt.DOB, GETDATE()) / 8766 AS Age
  ,'1' as SampleType
,plabs.OrderedbyDate as [DateofRequest]
  ,CASE WHEN plabs.ReceivedDatetime is null then plabs.OrderedbyDate else plabs.ReceivedDatetime  end AS[DateSampleCollected] 
  ,CASE 
    WHEN
    arv.regimen LIKE   '%3TC+EFV+TDF' THEN '4'
    WHEN  
	arv.regimen LIKE '%EFV/3TC/TDF' THEN '4'
	when
	 arv.regimen LIKE
	 '%3TC/TDF/EFV' then '4'
    WHEN
	arv.regimen LIKE '%3TC+AZT+NVP' THEN '1'
	WHEN 
	arv.regimen LIKE'%AZT/3TC/NVP' then  '1'
    WHEN 
	arv.regimen LIKE '%NVP/3TC/AZT' THEN '1'
	WHEN
	arv.regimen like '%3TC/NVP/AZT%' then '1'
    WHEN 
	arv.regimen LIKE '%3TC+AZT+EFV' THEN '2'
	when 
	arv.regimen like '%3TC/AZT/EFV%' then '2'
	WHEN 
	arv.regimen LIKE '%AZT/3TC/EFV' then '2'
    WHEN 
	 arv.regimen LIKE '%EFV/3TC/AZT' THEN '2'
	WHEN 
	arv.regimen LIKE '%3TC/NVP/TDF' then '3'
	WHEN 
	arv.regimen LIKE '%3TC/TDF/NVP%' then '3'
    WHEN 
	arv.regimen LIKE '%3TC+NVP+TDF' THEN '3'
    WHEN 
	arv.regimen LIKE '%NVP/3TC/TDF' THEN '3'
    WHEN 
	 arv.regimen LIKE '%3TC+AZT+LPV/r' THEN '5'
	WHEN  
   arv.regimen LIKE 	'%3TC/AZT/LOPr'   THEN '5'
	WHEN 
   arv.regimen LIKE 	'%3TC/AZT/LPV/r' then '5'
	WHEN 
  arv.regimen LIKE	'%LOPr/3TC/AZT'  then '5'
    WHEN 
 arv.regimen LIKE	'%LPVr/3TC/AZT' THEN '5'
    WHEN  
arv.regimen LIKE	'%3TC+ABC+AZT' THEN '6'
    WHEN 
   arv.regimen LIKE	'%3TC/ABC/AZT' then '6'
    WHEN 
	arv.regimen LIKE '%ABC/3TC/AZT' THEN '6'
    WHEN 
	arv.regimen LIKE '%3TC+LPVr+TDF' THEN '7'
	WHEN arv.regimen like '%3TC/TDF/LOPr%' then '7'
	WHEN arv.regimen like '%3TC/LOPr/TDF%' then '7'
    WHEN 
	 arv.regimen LIKE  '%LOPr/3TC/TDF%' THEN '7'
    WHEN 
	 arv.regimen LIKE  '%LPVr/3TC/TDF%' THEN '7'
    WHEN 
	arv.regimen LIKE
	'%3TC+ATVr+AZT%' THEN '8'
    WHEN 
     arv.regimen LIKE	'%ATVr/3TC/AZT%' THEN '8'
    WHEN 
     arv.regimen LIKE	'%3TC+ATVr+TDF%' THEN '9'
    WHEN 
	 arv.regimen LIKE  '%ATVr/3TC/TDF%' THEN '9'
    WHEN 
    arv.regimen LIKE 	'%3TC+ABC+ATVr%' THEN '10'
	WHEN  
    arv.regimen LIKE 	'%3TC/ABC/ATVr%' then'10'
    WHEN 
	 arv.regimen LIKE  '%ATVr/3TC/ABC%' THEN '10'
    WHEN 
	arv.regimen LIKE  '%3TC+ABC+NVP%' THEN '11'
	WHEN 
	arv.regimen LIKE  '%3TC/ABC/NVP%' then '11'
	WHEN 
	  arv.regimen LIKE '%ABC/3TC/NVP%' then '11'
    WHEN  
	arv.regimen LIKE '%NVP/3TC/ABC%' THEN '11'
    WHEN 
	arv.regimen LIKE  '%3TC+ABC+EFV%' THEN '12'
	WHEN  
	arv.regimen LIKE '%3TC/ABC/EFV%' then '12'
	WHEN  
	arv.regimen LIKE '%ABC/3TC/EFV%' then '12'
    WHEN 
	arv.regimen LIKE '%EFV/3TC/ABC%' THEN '12'

    WHEN arv.regimen LIKE  '%3TC+ABC+LPVr%' THEN '13'
	WHEN arv.regimen LIKE '%3TC/ABC/LOPr%' then '13'
	WHEN arv.regimen LIKE '%LOPr/ABC/3TC%' then '13'
    WHEN arv.regimen LIKE '%LPVr/3TC/ABC%' THEN '13'
    WHEN arv.regimen LIKE 'Other' THEN '14'
    WHEN  arv.regimen LIKE 'None' THEN '15'
    WHEN arv.regimen like  NULL  THEN '16'
    WHEN arv.regimen LIKE '%No Data' THEN '16'
	ELSE '0'
  END AS [Current Regimen],
  arv.dispenseDate  [Current ART Start Date],
  arvinitial.dispenseDate AS [Date Started On ART],
 CASE WHEN  plabs.Justification is null then '0' else plabs.Justification end  AS Justification,
  GETDATE() AS DateReceived,
 case when plabs.TestResultId='9998' then '0.00' else  plabs.TestResults  end as TestResults

from (
select a.LabID,a.Ptn_pk,a.LocationID,a.OrderedByName,a.OrderedByDate,a.ReportedByName,a.ReportedByDate,a.CheckedByName,a.CheckedByDate,a.PreClinicLabDate,CAST(Convert(nvarchar(10),lsp.ReceivedDatetime,101) as datetime) as ReceivedDatetime,
 a.LabPeriod,b.Justification,
               

b.LabTestID,c.SubTestId,b.TestResults,b.TestResults1,b.TestResultId,b.Financed,      

c.subtestname [SubTestName],d.LabTypeID 'LabTypeID',d.LabName,b.Units,e.name as UnitName,            

f.MinBoundaryValue,f.MaxBoundaryValue,a.LabNumber       

from ord_PatientlabOrder a       

left join mst_LabSpecimen  lsp   on lsp.LabID=a.LabID
inner join dtl_PatientLabResults b on a.labid = b.labid      

left outer join mst_Decode e on e.Id=b.Units  


left outer join lnk_labValue f  on  f.UnitId=b.units and f.SubTestId=b.ParameterId         

left outer join  lnk_testParameter c on c.subtestid=b.parameterId       

inner join mst_labtest d on c.testid=d.labtestid 
where d.LabName like '%Viral%'  and (a.DeleteFlag='0' or a.DeleteFlag is null))plabs
inner join mst_patient pt on pt.Ptn_pk=plabs.Ptn_Pk
LEFT JOIN mst_Facility f
  ON f.FacilityID = pt.LocationID
left join mst_Decode dc on dc.ID=pt.Sex
left join (
select arvlist.Ptn_Pk,arvlist.dispenseDate,
arvlist.regimen from(select arv.Ptn_Pk,arv.regimen,arv.dispenseDate,ROW_NUMBER() OVER(partition by arv.Ptn_pk order by arv.VisitID desc) as rownum  from(Select Distinct 
m.Ptn_pk,
a.VisitID,
a.DispensedByDate dispenseDate,

Case When g.RegimenType = '' Then f.DrugName Else g.RegimenType End As regimen,   
 SubString(g.RegimenType, 0, 4) [1],
Case
When CharIndex('/', g.RegimenType) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType) + 1, 3) End As [2],
Case
When CharIndex('/', g.RegimenType, 6) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType, 6) + 1, 3) Else Null End As [3],
Case
When CharIndex('/', g.RegimenType, 10) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType, 10) + 1, 3) Else Null End As [4],
Case
When CharIndex('/', g.RegimenType, 14) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType, 14) + 1, 3) Else Null End As [5],
--Max(b.Duration) duration,
h.Name Provider,
j.Name regimenLine,
i.Name treatmentType 



From mst_Patient m 
LEFT Join ord_PatientPharmacyOrder a On m.Ptn_Pk = a.Ptn_pk
LEFT join dtl_PatientPharmacyOrder b On a.ptn_pharmacy_pk = b.ptn_pharmacy_pk 
LEFT join lnk_DrugGeneric c on b.Drug_Pk = c.Drug_pk
LEFT join lnk_DrugTypeGeneric d on c.GenericID = d.GenericId
LEFT join mst_DrugType e on d.DrugTypeId = e.DrugTypeID 
LEFT join mst_Drug f on b.Drug_Pk = f.Drug_pk
LEFT Join dtl_RegimenMap g On a.VisitID = g.Visit_Pk
LEFT Join mst_Provider h On a.ProviderID = h.ID
LEFT Join mst_Decode i On a.ProgID = i.ID
LEFT Join mst_RegimenLine j On a.RegimenLine = j.ID

Where 
m.RegistrationDate <= a.DispensedByDate 

AND e.DrugTypeName = 'ARV Medication'
AND (a.DeleteFlag = 0 OR a.DeleteFlag IS NULL)
AND (m.DeleteFlag = 0 OR m.DeleteFlag IS NULL)
)arv )arvlist where arvlist.rownum='1')arv on arv.Ptn_Pk=pt.Ptn_Pk
left join (
select arvlist.Ptn_Pk,arvlist.dispenseDate,
arvlist.regimen from(select arv.Ptn_Pk,arv.regimen,arv.dispenseDate,ROW_NUMBER() OVER(partition by arv.Ptn_pk order by arv.VisitID asc) as rownum  from(Select Distinct 
m.Ptn_pk,
a.VisitID,
a.DispensedByDate dispenseDate,

Case When g.RegimenType = '' Then f.DrugName Else g.RegimenType End As regimen,   
 SubString(g.RegimenType, 0, 4) [1],
Case
When CharIndex('/', g.RegimenType) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType) + 1, 3) End As [2],
Case
When CharIndex('/', g.RegimenType, 6) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType, 6) + 1, 3) Else Null End As [3],
Case
When CharIndex('/', g.RegimenType, 10) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType, 10) + 1, 3) Else Null End As [4],
Case
When CharIndex('/', g.RegimenType, 14) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType, 14) + 1, 3) Else Null End As [5],
--Max(b.Duration) duration,
h.Name Provider,
j.Name regimenLine,
i.Name treatmentType 



From mst_Patient m 
LEFT Join ord_PatientPharmacyOrder a On m.Ptn_Pk = a.Ptn_pk
LEFT join dtl_PatientPharmacyOrder b On a.ptn_pharmacy_pk = b.ptn_pharmacy_pk 
LEFT join lnk_DrugGeneric c on b.Drug_Pk = c.Drug_pk
LEFT join lnk_DrugTypeGeneric d on c.GenericID = d.GenericId
LEFT join mst_DrugType e on d.DrugTypeId = e.DrugTypeID 
LEFT join mst_Drug f on b.Drug_Pk = f.Drug_pk
LEFT Join dtl_RegimenMap g On a.VisitID = g.Visit_Pk
LEFT Join mst_Provider h On a.ProviderID = h.ID
LEFT Join mst_Decode i On a.ProgID = i.ID
LEFT Join mst_RegimenLine j On a.RegimenLine = j.ID

Where 
m.RegistrationDate <= a.DispensedByDate 

AND e.DrugTypeName = 'ARV Medication'
AND (a.DeleteFlag = 0 OR a.DeleteFlag IS NULL)
AND (m.DeleteFlag = 0 OR m.DeleteFlag IS NULL)
)arv )arvlist where arvlist.rownum='1')arvinitial on arvinitial.Ptn_Pk=pt.Ptn_Pk
where plabs.OrderedbyDate between cast('@fromdate' as datetime) and cast('@todate' as datetime); 
";


        public static string VlLabList = @"
Open symmetric key Key_CTC decryption by password='ttwbvXWpqb5WOLfLrBgisw=='
select
convert(varchar(100),decryptbykey(pt.firstname))  + ' ' +  convert(varchar(100),decryptbykey(pt.LastName)) as FullName,
plabs.LabId,
CASE WHEN pt.PatientEnrollmentID is null or len(pt.PatientEnrollmentId) < 0 )  then pt.PatientClinicID
else pt.PatientEnrollmentID end   as ClientIpNo,
f.FacilityName,f.SatelliteID as MFLCode, CASE dc.Name
    WHEN 'Female' THEN '2'
    WHEN 'Male' THEN '1'
  END AS [Sex]
  , pt.DOB
  , DATEDIFF(HOUR, pt.DOB, GETDATE()) / 8766 AS Age
   ,'1' as SampleType
,plabs.OrderedbyDate as [DateofRequest]
   ,CASE WHEN plabs.ReceivedDatetime is null then plabs.OrderedbyDate else plabs.ReceivedDatetime  end AS[DateSampleCollected] 
  , CASE
    WHEN
    arv.regimen LIKE   '%3TC+EFV+TDF' THEN '4'
    WHEN
    arv.regimen LIKE '%EFV/3TC/TDF' THEN '4'

    when
     arv.regimen LIKE
	 '%3TC/TDF/EFV' then '4'
    WHEN

    arv.regimen LIKE '%3TC+AZT+NVP' THEN '1'

    WHEN
    arv.regimen LIKE'%AZT/3TC/NVP' then  '1'
    WHEN
    arv.regimen LIKE '%NVP/3TC/AZT' THEN '1'

    WHEN
    arv.regimen like '%3TC/NVP/AZT%' then '1'
    WHEN
    arv.regimen LIKE '%3TC+AZT+EFV' THEN '2'

    when
    arv.regimen like '%3TC/AZT/EFV%' then '2'

    WHEN
    arv.regimen LIKE '%AZT/3TC/EFV' then '2'
    WHEN
     arv.regimen LIKE '%EFV/3TC/AZT' THEN '2'

    WHEN
    arv.regimen LIKE '%3TC/NVP/TDF' then '3'

    WHEN
    arv.regimen LIKE '%3TC/TDF/NVP%' then '3'
    WHEN
    arv.regimen LIKE '%3TC+NVP+TDF' THEN '3'
    WHEN
    arv.regimen LIKE '%NVP/3TC/TDF' THEN '3'
    WHEN
     arv.regimen LIKE '%3TC+AZT+LPV/r' THEN '5'

    WHEN
   arv.regimen LIKE 	'%3TC/AZT/LOPr'   THEN '5'

    WHEN
   arv.regimen LIKE 	'%3TC/AZT/LPV/r' then '5'

    WHEN
  arv.regimen LIKE	'%LOPr/3TC/AZT'  then '5'
    WHEN
 arv.regimen LIKE	'%LPVr/3TC/AZT' THEN '5'
    WHEN
arv.regimen LIKE	'%3TC+ABC+AZT' THEN '6'
    WHEN
   arv.regimen LIKE	'%3TC/ABC/AZT' then '6'
    WHEN
    arv.regimen LIKE '%ABC/3TC/AZT' THEN '6'
    WHEN
    arv.regimen LIKE '%3TC+LPVr+TDF' THEN '7'

    WHEN arv.regimen like '%3TC/TDF/LOPr%' then '7'

    WHEN arv.regimen like '%3TC/LOPr/TDF%' then '7'
    WHEN
     arv.regimen LIKE  '%LOPr/3TC/TDF%' THEN '7'
    WHEN
     arv.regimen LIKE  '%LPVr/3TC/TDF%' THEN '7'
    WHEN
    arv.regimen LIKE
	'%3TC+ATVr+AZT%' THEN '8'
    WHEN
     arv.regimen LIKE	'%ATVr/3TC/AZT%' THEN '8'
    WHEN
     arv.regimen LIKE	'%3TC+ATVr+TDF%' THEN '9'
    WHEN
     arv.regimen LIKE  '%ATVr/3TC/TDF%' THEN '9'
    WHEN
    arv.regimen LIKE 	'%3TC+ABC+ATVr%' THEN '10'

    WHEN
    arv.regimen LIKE 	'%3TC/ABC/ATVr%' then'10'
    WHEN
     arv.regimen LIKE  '%ATVr/3TC/ABC%' THEN '10'
    WHEN
    arv.regimen LIKE  '%3TC+ABC+NVP%' THEN '11'

    WHEN
    arv.regimen LIKE  '%3TC/ABC/NVP%' then '11'

    WHEN
      arv.regimen LIKE '%ABC/3TC/NVP%' then '11'
    WHEN
    arv.regimen LIKE '%NVP/3TC/ABC%' THEN '11'
    WHEN
    arv.regimen LIKE  '%3TC+ABC+EFV%' THEN '12'

    WHEN
    arv.regimen LIKE '%3TC/ABC/EFV%' then '12'

    WHEN
    arv.regimen LIKE '%ABC/3TC/EFV%' then '12'
    WHEN
    arv.regimen LIKE '%EFV/3TC/ABC%' THEN '12'

    WHEN arv.regimen LIKE  '%3TC+ABC+LPVr%' THEN '13'

    WHEN arv.regimen LIKE '%3TC/ABC/LOPr%' then '13'

    WHEN arv.regimen LIKE '%LOPr/ABC/3TC%' then '13'
    WHEN arv.regimen LIKE '%LPVr/3TC/ABC%' THEN '13'
    WHEN arv.regimen LIKE 'Other' THEN '14'
    WHEN arv.regimen LIKE 'None' THEN '15'
    WHEN arv.regimen like  NULL THEN '16'
    WHEN arv.regimen LIKE '%No Data' THEN '16'

    ELSE '0'
  END AS [Current Regimen],
  arv.dispenseDate[Current ART Start Date],
  arvinitial.dispenseDate AS[Date Started On ART],
 CASE WHEN  plabs.Justification is null then '0' else plabs.Justification end  AS Justification,
  GETDATE() AS DateReceived

from(
select a.LabID, a.Ptn_pk, a.LocationID, a.OrderedByName, a.OrderedByDate, a.ReportedByName, a.ReportedByDate, a.CheckedByName, a.CheckedByDate, a.PreClinicLabDate,CAST(Convert(nvarchar(10),lsp.ReceivedDatetime,101) as datetime) as ReceivedDatetime,
 a.LabPeriod, b.Justification,


b.LabTestID, c.SubTestId, b.TestResults, b.TestResults1, b.TestResultId, b.Financed,

c.subtestname[SubTestName], d.LabTypeID 'LabTypeID', d.LabName, b.Units, e.name as UnitName,

f.MinBoundaryValue, f.MaxBoundaryValue, a.LabNumber

from ord_PatientlabOrder a
left join mst_LabSpecimen  lsp   on lsp.LabID=a.LabID

inner join dtl_PatientLabResults b on a.labid = b.labid

left outer join mst_Decode e on e.Id= b.Units


left outer join lnk_labValue f on  f.UnitId= b.units and f.SubTestId= b.ParameterId

left outer join lnk_testParameter c on c.subtestid= b.parameterId

inner join mst_labtest d on c.testid= d.labtestid
where d.LabName like '%Viral%'
and (a.DeleteFlag= '0' or a.DeleteFlag is null))plabs
 inner join mst_patient pt on pt.Ptn_pk=plabs.Ptn_Pk
 LEFT JOIN mst_Facility f
   ON f.FacilityID = pt.LocationID
 left join mst_Decode dc on dc.ID=pt.Sex
 left join(
 select arvlist.Ptn_Pk, arvlist.dispenseDate,
 arvlist.regimen from(select arv.Ptn_Pk, arv.regimen, arv.dispenseDate, ROW_NUMBER() OVER(partition by arv.Ptn_pk order by arv.VisitID desc) as rownum from(Select Distinct
 
    m.Ptn_pk,
    a.VisitID,
    a.DispensedByDate dispenseDate,

    Case When g.RegimenType = '' Then f.DrugName Else g.RegimenType End As regimen,
     SubString(g.RegimenType, 0, 4) [1],
Case
When CharIndex('/', g.RegimenType) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType) + 1, 3) End As[2],
Case
When CharIndex('/', g.RegimenType, 6) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType, 6) + 1, 3) Else Null End As[3],
Case
When CharIndex('/', g.RegimenType, 10) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType, 10) + 1, 3) Else Null End As[4],
Case
When CharIndex('/', g.RegimenType, 14) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType, 14) + 1, 3) Else Null End As[5],
--Max(b.Duration) duration,
h.Name Provider,
j.Name regimenLine,
i.Name treatmentType



From mst_Patient m
LEFT Join ord_PatientPharmacyOrder a On m.Ptn_Pk = a.Ptn_pk
LEFT join dtl_PatientPharmacyOrder b On a.ptn_pharmacy_pk = b.ptn_pharmacy_pk
LEFT join lnk_DrugGeneric c on b.Drug_Pk = c.Drug_pk
LEFT join lnk_DrugTypeGeneric d on c.GenericID = d.GenericId
LEFT join mst_DrugType e on d.DrugTypeId = e.DrugTypeID
LEFT join mst_Drug f on b.Drug_Pk = f.Drug_pk
LEFT Join dtl_RegimenMap g On a.VisitID = g.Visit_Pk
LEFT Join mst_Provider h On a.ProviderID = h.ID
LEFT Join mst_Decode i On a.ProgID = i.ID
LEFT Join mst_RegimenLine j On a.RegimenLine = j.ID

Where
m.RegistrationDate <= a.DispensedByDate

AND e.DrugTypeName = 'ARV Medication'
AND(a.DeleteFlag = 0 OR a.DeleteFlag IS NULL)
AND(m.DeleteFlag = 0 OR m.DeleteFlag IS NULL)
)arv )arvlist where arvlist.rownum='1')arv on arv.Ptn_Pk=pt.Ptn_Pk
left join(
select arvlist.Ptn_Pk, arvlist.dispenseDate,
arvlist.regimen from(select arv.Ptn_Pk, arv.regimen, arv.dispenseDate, ROW_NUMBER() OVER(partition by arv.Ptn_pk order by arv.VisitID asc) as rownum from(Select Distinct
   m.Ptn_pk,
   a.VisitID,
   a.DispensedByDate dispenseDate,

   Case When g.RegimenType = '' Then f.DrugName Else g.RegimenType End As regimen,
    SubString(g.RegimenType, 0, 4) [1],
Case
When CharIndex('/', g.RegimenType) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType) + 1, 3) End As[2],
Case
When CharIndex('/', g.RegimenType, 6) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType, 6) + 1, 3) Else Null End As[3],
Case
When CharIndex('/', g.RegimenType, 10) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType, 10) + 1, 3) Else Null End As[4],
Case
When CharIndex('/', g.RegimenType, 14) > 0 Then SubString(g.RegimenType,
CharIndex('/', g.RegimenType, 14) + 1, 3) Else Null End As[5],
--Max(b.Duration) duration,
h.Name Provider,
j.Name regimenLine,
i.Name treatmentType



From mst_Patient m
LEFT Join ord_PatientPharmacyOrder a On m.Ptn_Pk = a.Ptn_pk
LEFT join dtl_PatientPharmacyOrder b On a.ptn_pharmacy_pk = b.ptn_pharmacy_pk
LEFT join lnk_DrugGeneric c on b.Drug_Pk = c.Drug_pk
LEFT join lnk_DrugTypeGeneric d on c.GenericID = d.GenericId
LEFT join mst_DrugType e on d.DrugTypeId = e.DrugTypeID
LEFT join mst_Drug f on b.Drug_Pk = f.Drug_pk
LEFT Join dtl_RegimenMap g On a.VisitID = g.Visit_Pk
LEFT Join mst_Provider h On a.ProviderID = h.ID
LEFT Join mst_Decode i On a.ProgID = i.ID
LEFT Join mst_RegimenLine j On a.RegimenLine = j.ID

Where
m.RegistrationDate <= a.DispensedByDate

AND e.DrugTypeName = 'ARV Medication'
AND(a.DeleteFlag = 0 OR a.DeleteFlag IS NULL)
AND(m.DeleteFlag = 0 OR m.DeleteFlag IS NULL)
)arv )arvlist where arvlist.rownum='1')arvinitial on arvinitial.Ptn_Pk=pt.Ptn_Pk
where plabs.TestResults is null and plabs.LabId=@LabOrderId;


";
    }



}
