delimiter $$

CREATE DATABASE `hfbbs` /*!40100 DEFAULT CHARACTER SET utf8 */$$

delimiter $$

CREATE TABLE `downloaddata` (
  `ID` int(11) NOT NULL auto_increment,
  `TaskId` int(11) default NULL,
  `Title` text,
  `SubTitle` text,
  `Keywords` text,
  `news_source_name` text,
  `news_template_file` text,
  `news_top` text,
  `news_guideimage` text,
  `news_guideimage2` text,
  `news_description` text,
  `news_link` text,
  `news_down` text,
  `news_right` text,
  `news_left` text,
  `comment_url` text,
  `news_video` text,
  `news_keywords2` text,
  `label_base` text,
  `cmspinglun` bit(1) NOT NULL default '\0',
  `bbspinglun` bit(1) NOT NULL default '\0',
  `ISkfbm` bit(1) NOT NULL default '\0',
  `kfbm_id` text,
  `kfbm_link` text,
  `ISgfbm` bit(1) NOT NULL default '\0',
  `gfbm_id` text,
  `gfbm_link` text,
  `news_abs` text,
  `Content` text,
  `Summary` text,
  `Source` text,
  `CreateTime` text,
  `Other` text,
  `Url` text,
  `IsEdit` bit(1) NOT NULL default '\0',
  `EditorUserName` text,
  `DownloadTime` datetime default NULL,
  `IsDownload` bit(1) NOT NULL default '\0',
  `IsPublish` bit(1) NOT NULL default '\0',
  `EditTime` datetime default NULL,
  `RemoteId` int(11) NOT NULL default '0',
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8$$

